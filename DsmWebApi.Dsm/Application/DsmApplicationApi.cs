namespace DsmWebApi.Dsm.Application
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM application API.
    /// </summary>
    public class DsmApplicationApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM application API.
        /// </summary>
        private const string DsmApplicationApiName = "SYNO.DSM.Application";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApplicationApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmApplicationApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmApplicationApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of applications on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the applications to retrieve in the list of applications.</param>
        /// <param name="limit">The number of applications to retrieve in the list of applications.</param>
        /// <returns>A list of applications on the DSM system.</returns>
        public async Task<DsmApplicationCollection> List(int? offset, int? limit)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
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
                DsmApplicationApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmApplicationCollection = JsonConvert.DeserializeObject<DsmApplicationCollection>(response.Data.ToString());

            // The DSM application API seems to reports a total count that is one over the real total count of applications.
            dsmApplicationCollection.Total -= 1;
            return dsmApplicationCollection;
        }
    }
}
