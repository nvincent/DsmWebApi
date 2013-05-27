namespace DsmWebApi.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
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
            this.ApiInfo = this.ApiContext.AllApiInfo.SingleOrDefault(ai => ai.Name == api);
            if (this.ApiInfo == null)
            {
                string message = string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.UnsupportedApiMessage,
                    api);
                throw new NotSupportedException(message);
            }

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
    }
}
