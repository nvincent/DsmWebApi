namespace DsmWebApi.Dsm.LogViewer
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
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
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "The async pattern requires to nest the return type in a Task.")]
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

        /// <summary>
        /// Gets a list of groups on the DSM system.
        /// </summary>
        /// <param name="logType">The type of log entries to query. Must be one of the strings returned by <see cref="Supported"/>.</param>
        /// <param name="offset">The offset of the groups to retrieve in the list of groups.</param>
        /// <param name="limit">The number of groups to retrieve in the list of groups.</param>
        /// <returns>A list of groups on the DSM system.</returns>
        public async Task<DsmLogEntryCollection> List(string logType, int? offset, int? limit)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "logtype", logType }
            };
            if (offset.HasValue)
            {
                parameters.Add("offset", offset.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (limit.HasValue)
            {
                parameters.Add("limit", limit.Value.ToString(CultureInfo.InvariantCulture));
            }

            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmLogViewerApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmLogEntryCollection = JsonConvert.DeserializeObject<DsmLogEntryCollection>(response.Data.ToString());
            return dsmLogEntryCollection;
        }
    }
}
