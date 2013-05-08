namespace DsmWebApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Default implementation of the DSM API context based on the Web API of Synology's DSM system.
    /// </summary>
    public class DsmWebApiContext : IDsmApiContext
    {
        /// <summary>
        /// Name of the HTTP GET parameter containing the name of the requested API.
        /// </summary>
        private const string ApiParameterName = "api";

        /// <summary>
        /// Name of the JSON property containing the data of the response when the request was successful.
        /// </summary>
        private const string DataPropertyName = "data";

        /// <summary>
        /// Name of the JSON property containing the error object in case the request was not successful.
        /// </summary>
        private const string ErrorPropertyName = "error";

        /// <summary>
        /// Name of the JSON property of the error object containing the code of the error.
        /// </summary>
        private const string ErrorCodePropertyName = "code";

        /// <summary>
        /// Name of the HTTP GET parameter containing the requested method of the API.
        /// </summary>
        private const string MethodParameterName = "method";

        /// <summary>
        /// Name of the JSON property containing a boolean indicating whether the request has been successful.
        /// </summary>
        private const string SuccessPropertyName = "success";

        /// <summary>
        /// Name of the HTTP GET parameter containing the version of the requested API.
        /// </summary>
        private const string VersionParameterName = "version";

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
        public DsmApiResponse Request(string apiPath, string api, int version, string method, IDictionary<string, string> additionalParameters)
        {
            Uri requestUri = this.BuildRequestUri(apiPath, api, version, method, additionalParameters);
            JObject responseObject;
            using (WebResponse response = this.ExecuteRequest(requestUri))
            {
                responseObject = GetJsonObjectFromWebResponse(response);
            }

            DsmApiResponse apiResponse = ConvertResponseObjectToApiResponse(responseObject);
            return apiResponse;
        }

        /// <inheritdoc />
        public DsmApiInfo GetApiInfo(string api)
        {
            DsmApiResponse response = this.Request(
                "query.cgi",
                "SYNO.API.Info",
                1,
                "query",
                new Dictionary<string, string>()
                {
                    { "query", api }
                });

            if (response.Success)
            {
                var metadata = response.Data.Children().First().Children().First();
                string path = metadata["path"].ToString();
                int minVersion = metadata["minVersion"].Value<int>();
                int maxVersion = metadata["maxVersion"].Value<int>();

                DsmApiInfo apiInfo = new DsmApiInfo(path, minVersion, maxVersion);
                return apiInfo;
            }
            else
            {
                return null;
            }
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
            bool success = responseObject.Property(SuccessPropertyName).Value.Value<bool>();
            if (success)
            {
                JProperty dataProperty = responseObject.Property(DataPropertyName);
                JObject data = dataProperty == null ? null : dataProperty.Value.Value<JObject>();
                apiResponse = new DsmApiResponse(data);
            }
            else
            {
                JObject error = responseObject.Property(ErrorPropertyName).Value.Value<JObject>();
                int errorCode = error.Property(ErrorCodePropertyName).Value.Value<int>();
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
            httpGetParameters.Add(ApiParameterName, api);
            httpGetParameters.Add(VersionParameterName, version.ToString(CultureInfo.InvariantCulture));
            httpGetParameters.Add(MethodParameterName, method);
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
        private WebResponse ExecuteRequest(Uri requestUri)
        {
            var webRequest = HttpWebRequest.CreateHttp(requestUri);
            webRequest.CookieContainer = this.CookieContainer;
            var asyncResult = webRequest.BeginGetResponse(null, null);
            var response = (HttpWebResponse)webRequest.EndGetResponse(asyncResult);
            this.CookieContainer.Add(this.BaseUri, response.Cookies);
            return response;
        }
    }
}
