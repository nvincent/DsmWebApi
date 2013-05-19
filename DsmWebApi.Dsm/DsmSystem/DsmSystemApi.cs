namespace DsmWebApi.Dsm.DsmSystem
{
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The DSM system API.
    /// </summary>
    public class DsmSystemApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM system API.
        /// </summary>
        private const string DsmSystemApiName = "SYNO.DSM.System";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmSystemApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmSystemApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmSystemApiName, 1)
        {
        }

        /// <summary>
        /// Reboots the DSM system.
        /// </summary>
        /// <returns>The response of the reboot request.</returns>
        public async Task<DsmApiResponse> Reboot()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemApiName,
                this.ApiInfo.MaxVersion,
                "reboot",
                null);
            return response;
        }

        /// <summary>
        /// Shutdowns the DSM system.
        /// </summary>
        /// <returns>The response of the shutdown request.</returns>
        public async Task<DsmApiResponse> Shutdown()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemApiName,
                this.ApiInfo.MaxVersion,
                "shutdown",
                null);
            return response;
        }

        /// <summary>
        /// Pings the DSM system and makes sure the boot sequence is over.
        /// </summary>
        /// <returns>A value indicating whether the boot sequence is over.</returns>
        public async Task<bool> PingPong()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemApiName,
                this.ApiInfo.MaxVersion,
                "pingpong",
                null);
            bool bootDone = response.Data["boot_done"].Value<bool>();
            return bootDone;
        }
    }
}
