namespace DsmWebApi.Dsm.IScsi
{
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM iSCSI API.
    /// </summary>
    public class DsmIScsiApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM iSCSI API.
        /// </summary>
        private const string DsmIScsiApiName = "SYNO.DSM.iSCSI";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmIScsiApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmIScsiApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmIScsiApiName, 1)
        {
        }

        /// <summary>
        /// Gets the iSCSI configuration of the DSM system.
        /// </summary>
        /// <returns>The iSCSI configuration of the DSM system.</returns>
        public async Task<DsmIScsiConfiguration> List()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmIScsiApiName,
                this.ApiInfo.MaxVersion,
                "list",
                null);
            var dsmIScsiConfiguration = JsonConvert.DeserializeObject<DsmIScsiConfiguration>(response.Data.ToString());
            return dsmIScsiConfiguration;
        }
    }
}
