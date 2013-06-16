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
        /// <returns>The task containing the reboot operation.</returns>
        public async Task Reboot()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemApiName,
                this.ApiInfo.MaxVersion,
                "reboot",
                null);
        }

        /// <summary>
        /// Shutdowns the DSM system.
        /// </summary>
        /// <returns>The task containing the shutdown operation.</returns>
        public async Task Shutdown()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemApiName,
                this.ApiInfo.MaxVersion,
                "shutdown",
                null);
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
