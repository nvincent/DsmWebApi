namespace DsmWebApi.Dsm.Network
{
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM network API.
    /// </summary>
    public class DsmNetworkApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM network API.
        /// </summary>
        private const string DsmNetworkApiName = "SYNO.DSM.Network";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmNetworkApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmNetworkApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmNetworkApiName, 1)
        {
        }

        /// <summary>
        /// Gets the network configuration of the DSM system.
        /// </summary>
        /// <returns>The network configuration of the DSM system.</returns>
        public async Task<DsmNetworkConfiguration> List()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmNetworkApiName,
                this.ApiInfo.MaxVersion,
                "list",
                null);
            var dsmNetworkConfiguration = JsonConvert.DeserializeObject<DsmNetworkConfiguration>(response.Data.ToString());
            return dsmNetworkConfiguration;
        }
    }
}
