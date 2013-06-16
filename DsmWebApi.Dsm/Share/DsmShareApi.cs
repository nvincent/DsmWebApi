namespace DsmWebApi.Dsm.Share
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM share API.
    /// </summary>
    public class DsmShareApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM share API.
        /// </summary>
        private const string DsmShareApiName = "SYNO.DSM.Share";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmShareApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmShareApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmShareApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of shares on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the shares to retrieve in the list of shares.</param>
        /// <param name="limit">The number of shares to retrieve in the list of shares.</param>
        /// <returns>A list of shares on the DSM system.</returns>
        public async Task<DsmShareCollection> List(int? offset, int? limit)
        {
            var parameters = new Dictionary<string, string>();
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
                DsmShareApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmShareCollection = JsonConvert.DeserializeObject<DsmShareCollection>(response.Data.ToString());
            return dsmShareCollection;
        }
    }
}
