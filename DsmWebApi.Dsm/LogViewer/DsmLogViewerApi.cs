namespace DsmWebApi.Dsm.LogViewer
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM log viewer API.
    /// </summary>
    public class DsmLogViewerApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM log viewer API.
        /// </summary>
        private const string DsmLogViewerApiName = "SYNO.DSM.LogViewer";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmLogViewerApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmLogViewerApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmLogViewerApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of supported logs on the DSM system.
        /// </summary>
        /// <returns>A list of supported logs on the DSM system.</returns>
        public async Task<IEnumerable<string>> Supported()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmLogViewerApiName,
                this.ApiInfo.MaxVersion,
                "supported",
                null);
            var supportedLogs = JsonConvert.DeserializeObject<IEnumerable<string>>(response.Data.ToString());
            return supportedLogs;
        }
    }
}
