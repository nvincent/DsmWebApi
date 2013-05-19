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
        /// <param name="offset">The offset of the shares collection to query.</param>
        /// <returns>A list of shares on the DSM system.</returns>
        public async Task<DsmShareCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmShareApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmShareCollection = JsonConvert.DeserializeObject<DsmShareCollection>(response.Data.ToString());
            return dsmShareCollection;
        }
    }
}
