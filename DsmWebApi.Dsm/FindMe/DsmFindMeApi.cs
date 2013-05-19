namespace DsmWebApi.Dsm.FindMe
{
    using System.Threading.Tasks;
    using DsmWebApi.Core;

    /// <summary>
    /// The DSM Find Me API.
    /// </summary>
    public class DsmFindMeApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM Find Me API.
        /// </summary>
        private const string DsmFindMeApiName = "SYNO.DSM.FindMe";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmFindMeApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmFindMeApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmFindMeApiName, 1)
        {
        }

        /// <summary>
        /// Starts the Find Me beeps.
        /// </summary>
        /// <returns>The response of the start request.</returns>
        public async Task<DsmApiResponse> Start()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmFindMeApiName,
                this.ApiInfo.MaxVersion,
                "start",
                null);
            return response;
        }

        /// <summary>
        /// Stops the Find Me beeps.
        /// </summary>
        /// <returns>The response of the stop request.</returns>
        public async Task<DsmApiResponse> Stop()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmFindMeApiName,
                this.ApiInfo.MaxVersion,
                "stop",
                null);
            return response;
        }

        /// <summary>
        /// Indicates whether the "Find Me" feature is supported.
        /// </summary>
        /// <returns>A value indicating whether the "Find Me" feature is supported.</returns>
        public async Task<bool> Supported()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmFindMeApiName,
                this.ApiInfo.MaxVersion,
                "supported",
                null);
            bool supported = response.Success;
            return supported;
        }
    }
}
