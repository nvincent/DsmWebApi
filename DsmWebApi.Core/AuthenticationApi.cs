namespace DsmWebApi.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// The DSM authentication API.
    /// </summary>
    public class AuthenticationApi : DsmApiBase
    {
        /// <summary>
        /// The name of the authentication API.
        /// </summary>
        private const string AuthenticationApiName = "SYNO.API.Auth";

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public AuthenticationApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, AuthenticationApiName, 3)
        {
        }

        /// <summary>
        /// Logs on the DSM system.
        /// </summary>
        /// <param name="account">The name of the account.</param>
        /// <param name="password">The password of the account.</param>
        public DsmApiResponse LogOn(string account, string password)
        {
            DsmApiResponse response = this.ApiContext.Request(
                this.ApiInfo.Path,
                AuthenticationApiName,
                this.ApiInfo.MaxVersion,
                "login",
                new Dictionary<string, string>()
                {
                    { "account", account },
                    { "passwd", password }
                });
            return response;
        }

        /// <summary>
        /// Logs off the DSM system.
        /// </summary>
        public DsmApiResponse LogOff()
        {
            DsmApiResponse response = this.ApiContext.Request(
                this.ApiInfo.Path,
                AuthenticationApiName,
                this.ApiInfo.MaxVersion,
                "logout",
                null);
            return response;
        }
    }
}
