namespace DsmWebApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Default implementation of the DSM API context based on the Web API of Synology's DSM system.
    /// </summary>
    public class DsmWebApiContext : IDsmApiContext
    {
        /// <summary>
        /// Cache field for the return value of the <see cref="GetAllApiInfo"/> method.
        /// </summary>
        private IEnumerable<DsmApiInfo> getAllApiInfoCachedReturnValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmWebApiContext"/> class.
        /// </summary>
        /// <param name="webApiBaseUri">Base URI of the web API.</param>
        public DsmWebApiContext(Uri webApiBaseUri)
        {
            if (webApiBaseUri == null)
            {
                throw new ArgumentNullException("webApiBaseUri");
            }

            this.BaseUri = webApiBaseUri;
            this.CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Gets the base URI of the Web API (for example, "http://192.168.0.1:5000/webapi/").
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="CookieContainer"/> containing cookies sent with each request, especially the authentication cookie.
        /// </summary>
        private CookieContainer CookieContainer { get; set; }

        /// <inheritdoc />
        public async Task<DsmApiResponse> Request(string apiPath, string api, int version, string method, IDictionary<string, string> additionalParameters)
        {
            Uri requestUri = this.BuildRequestUri(apiPath, api, version, method, additionalParameters);
            JObject responseObject;
            using (WebResponse response = await this.ExecuteRequest(requestUri))
            {
                responseObject = GetJsonObjectFromWebResponse(response);
            }

            DsmApiResponse apiResponse = ConvertResponseObjectToApiResponse(responseObject);
            return apiResponse;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<DsmApiInfo>> GetAllApiInfo()
        {
            if (this.getAllApiInfoCachedReturnValue == null)
            {
                DsmApiResponse response = await this.Request(
                    "query.cgi",
                    "SYNO.API.Info",
                    1,
                    "query",
                    new Dictionary<string, string>()
                    {
                        { "query", "all" }
                    });

                if (response.Success)
                {
                    this.getAllApiInfoCachedReturnValue = response.Data.Children().OfType<JProperty>().Select(p => DsmApiInfo.ConvertFrom(p));
                }
            }

            return this.getAllApiInfoCachedReturnValue;
        }

        /// <summary>
        /// Gets the <see cref="JObject"/> contained in the response to an API query.
        /// </summary>
        /// <param name="response">The response to the query.</param>
        /// <returns>The JSON representation of the body of the response.</returns>
        private static JObject GetJsonObjectFromWebResponse(WebResponse response)
        {
            JObject responseObject;
            Stream responseStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    responseStream = null;
                    string responseText = responseReader.ReadToEnd();
                    responseObject = JObject.Parse(responseText);
                }
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Dispose();
                }
            }

            return responseObject;
        }

        /// <summary>
        /// Converts the JSON response wrapper to a <see cref="DsmApiResponse"/> object.
        /// </summary>
        /// <param name="responseObject">The JSON wrapper of the response.</param>
        /// <returns>The <see cref="DsmApiResponse"/> object containing the data in the response wrapper.</returns>
        private static DsmApiResponse ConvertResponseObjectToApiResponse(JObject responseObject)
        {
            DsmApiResponse apiResponse;
            bool success = responseObject.Property("success").Value.Value<bool>();
            if (success)
            {
                JProperty dataProperty = responseObject.Property("data");
                JToken data = dataProperty == null ? null : dataProperty.Value;
                apiResponse = new DsmApiResponse(data);
            }
            else
            {
                JObject error = responseObject.Property("error").Value.Value<JObject>();
                int errorCode = error.Property("code").Value.Value<int>();
                apiResponse = new DsmApiResponse(errorCode);
            }

            return apiResponse;
        }

        /// <summary>
        /// Builds the request URI from common and API-specific parameters.
        /// </summary>
        /// <param name="apiPath">The path of the API.</param>
        /// <param name="api">The name of the API.</param>
        /// <param name="version">The version of the API.</param>
        /// <param name="method">The requested method of the API.</param>
        /// <param name="additionalParameters">Additional parameters of the request.</param>
        /// <returns>The full URI to request.</returns>
        private Uri BuildRequestUri(string apiPath, string api, int version, string method, IDictionary<string, string> additionalParameters)
        {
            Uri requestUri = new Uri(this.BaseUri, apiPath);
            UriBuilder uriBuilder = new UriBuilder(requestUri);

            IDictionary<string, string> httpGetParameters = new Dictionary<string, string>();
            httpGetParameters.Add("api", api);
            httpGetParameters.Add("version", version.ToString(CultureInfo.InvariantCulture));
            httpGetParameters.Add("method", method);
            if (additionalParameters != null && additionalParameters.Count > 0)
            {
                foreach (var additionalParameter in additionalParameters)
                {
                    httpGetParameters.Add(additionalParameter);
                }
            }

            if (httpGetParameters.Count > 0)
            {
                var queryStringParams = httpGetParameters.Select(p => p.Key + "=" + p.Value);
                uriBuilder.Query = string.Join("&", queryStringParams.ToArray());
            }

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Executes a Web API request.
        /// </summary>
        /// <param name="requestUri">The URI of the request.</param>
        /// <returns>The response of the request.</returns>
        private async Task<WebResponse> ExecuteRequest(Uri requestUri)
        {
            var webRequest = HttpWebRequest.CreateHttp(requestUri);
            webRequest.CookieContainer = this.CookieContainer;
            var response = (HttpWebResponse)await webRequest.GetResponseAsync();
            this.CookieContainer.Add(this.BaseUri, response.Cookies);
            return response;
        }
    }
}
