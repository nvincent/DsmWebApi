namespace DsmWebApi.Dsm
{
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
        public DsmApiResponse Reboot()
        {
            DsmApiResponse response = this.ApiContext.Request(
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
        public DsmApiResponse Shutdown()
        {
            DsmApiResponse response = this.ApiContext.Request(
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
        public bool PingPong()
        {
            DsmApiResponse response = this.ApiContext.Request(
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
