namespace DsmWebApi.Dsm.AutoBlock
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM auto block API.
    /// </summary>
    public class DsmAutoBlockApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM auto block API.
        /// </summary>
        private const string DsmAutoBlockApiName = "SYNO.DSM.AutoBlock";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmAutoBlockApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmAutoBlockApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmAutoBlockApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of blocked addresses on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the blocked addresses collection to query.</param>
        /// <returns>A list of blocked addresses on the DSM system.</returns>
        public async Task<DsmBlockedAddressCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmAutoBlockApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmBlockedAddressCollection = JsonConvert.DeserializeObject<DsmBlockedAddressCollection>(response.Data.ToString());
            return dsmBlockedAddressCollection;
        }

        /// <summary>
        /// Gets the Auto Block configuration.
        /// </summary>
        /// <returns>The Auto Block configuration.</returns>
        public async Task<DsmAutoBlockConfiguration> GetConfig()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmAutoBlockApiName,
                this.ApiInfo.MaxVersion,
                "getconfig",
                null);
            var dsmAutoBlockConfiguration = JsonConvert.DeserializeObject<DsmAutoBlockConfiguration>(response.Data.ToString());
            return dsmAutoBlockConfiguration;
        }

        /// <summary>
        /// Sets the Auto Block configuration.
        /// </summary>
        /// <param name="configuration">The new value of the configuration.</param>
        /// <returns>The response of the set configuration request.</returns>
        public async Task<DsmApiResponse> SetConfig(DsmAutoBlockConfiguration configuration)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmAutoBlockApiName,
                this.ApiInfo.MaxVersion,
                "setconfig",
                new Dictionary<string, string>()
                {
                    { "attemptmin", configuration.AttemptsPeriod.ToString(CultureInfo.InvariantCulture) },
                    { "attempts", configuration.Attempts.ToString(CultureInfo.InvariantCulture) },
                    { "expiredday", configuration.ExpiredDay.ToString(CultureInfo.InvariantCulture) }
                });
            return response;
        }
    }
}
