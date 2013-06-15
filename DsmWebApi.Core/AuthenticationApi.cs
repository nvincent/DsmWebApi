namespace DsmWebApi.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

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
        /// <returns>The information about the authenticated connection.</returns>
        public async Task<AuthenticationInformation> LogOn(string account, string password)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                AuthenticationApiName,
                this.ApiInfo.MaxVersion,
                "login",
                new Dictionary<string, string>()
                {
                    { "account", account },
                    { "passwd", password }
                });
            var authenticationInformation = JsonConvert.DeserializeObject<AuthenticationInformation>(response.Data.ToString());
            return authenticationInformation;
        }

        /// <summary>
        /// Logs off the DSM system.
        /// </summary>
        /// <returns>The response of the log off request.</returns>
        public async Task LogOff()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                AuthenticationApiName,
                this.ApiInfo.MaxVersion,
                "logout",
                null);
        }
    }
}
