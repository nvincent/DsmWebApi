namespace DsmWebApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using DsmWebApi.Core.Properties;
    using Newtonsoft.Json;

    /// <summary>
    /// Default implementation of the DSM API context based on the Web API of Synology's DSM system.
    /// </summary>
    public class DsmWebApiContext : IDsmApiContext
    {
        /// <summary>
        /// Storage field for the <see cref="AllApiInfo"/> property.
        /// </summary>
        private IDictionary<string, DsmApiInfo> allApiInfo;

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

        /// <inheritdoc />
        public IDictionary<string, DsmApiInfo> AllApiInfo
        {
            get { return this.allApiInfo; }
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
            string responseString;
            using (WebResponse response = await this.ExecuteRequest(requestUri))
            {
                responseString = GetJsonStringFromWebResponse(response);
            }

            DsmApiResponse apiResponse = JsonConvert.DeserializeObject<DsmApiResponse>(responseString);
            if (!apiResponse.Success)
            {
                throw new DsmApiException(apiResponse.Error.Code, this.ConvertErrorCodeToErrorMessage(apiResponse.Error.Code));
            }

            return apiResponse;
        }

        /// <inheritdoc />
        public async Task LoadAllApiInfo()
        {
            if (this.allApiInfo == null)
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
                    this.allApiInfo = JsonConvert.DeserializeObject<Dictionary<string, DsmApiInfo>>(response.Data.ToString());
                }
            }
        }

        /// <summary>
        /// Converts an error code to a localized message.
        /// </summary>
        /// <param name="errorCode">The error code to convert.</param>
        /// <returns>The localized message.</returns>
        protected virtual string ConvertErrorCodeToErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 100:
                    return Resources.UnknownErrorMessage;
                case 101:
                    return Resources.InvalidParametersMessage;
                case 102:
                    return Resources.ApiDoesNotExistMessage;
                case 103:
                    return Resources.MethodDoesNotExist;
                case 104:
                    return Resources.ApiVersionNotSupported;
                case 105:
                    return Resources.InsufficientUserPrivilegeMessage;
                case 106:
                    return Resources.ConnectionTimeOutMessage;
                case 107:
                    return Resources.MultipleLoginDetected;
                default:
                    return Resources.UnknownErrorCodeMessage;
            }
        }

        /// <summary>
        /// Gets the JSON string contained in the response to an API query.
        /// </summary>
        /// <param name="response">The response to the query.</param>
        /// <returns>The JSON string representation of the body of the response.</returns>
        private static string GetJsonStringFromWebResponse(WebResponse response)
        {
            string responseString;
            Stream responseStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                using (StreamReader responseReader = new StreamReader(responseStream))
                {
                    responseStream = null;
                    responseString = responseReader.ReadToEnd();
                }
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Dispose();
                }
            }

            return responseString;
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
