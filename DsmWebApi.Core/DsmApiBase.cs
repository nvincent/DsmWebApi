namespace DsmWebApi.Core
{
    using System;
    using System.Globalization;
    using DsmWebApi.Core.Properties;

    /// <summary>
    /// Base implementation of a DSM API.
    /// </summary>
    public abstract class DsmApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiBase"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        /// <param name="api">The name of the API.</param>
        /// <param name="supportedApiVersion">The supported version of the API.</param>
        protected DsmApiBase(IDsmApiContext dsmApiContext, string api, int supportedApiVersion)
        {
            if (dsmApiContext == null)
            {
                throw new ArgumentNullException("dsmApiContext");
            }

            this.ApiContext = dsmApiContext;
            DsmApiInfo apiInfo;
            if (!this.ApiContext.AllApiInfo.TryGetValue(api, out apiInfo))
            {
                string message = string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.UnsupportedApiMessage,
                    api);
                throw new NotSupportedException(message);
            }

            this.ApiInfo = apiInfo;
            if (supportedApiVersion < this.ApiInfo.MinVersion || supportedApiVersion > this.ApiInfo.MaxVersion)
            {
                string message = string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.UnsupportedApiVersionMessage,
                    supportedApiVersion,
                    this.ApiInfo.MinVersion,
                    this.ApiInfo.MaxVersion);
                throw new NotSupportedException(message);
            }
        }

        /// <summary>
        /// Gets the information about the authentication API.
        /// </summary>
        public DsmApiInfo ApiInfo { get; private set; }

        /// <summary>
        /// Gets the context used to access the DSM API.
        /// </summary>
        protected IDsmApiContext ApiContext { get; private set; }

        /// <summary>
        /// Throws a <see cref="DsmApiException"/> with the correct error code and message when the response contains an error.
        /// </summary>
        /// <param name="apiResponse">The response to check.</param>
        protected void ThrowIfError(DsmApiResponse apiResponse)
        {
            if (!apiResponse.Success)
            {
                throw new DsmApiException(apiResponse.Error.Code, this.ConvertErrorCodeToErrorMessage(apiResponse.Error.Code));
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
    }
}
