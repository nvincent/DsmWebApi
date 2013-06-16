namespace DsmWebApi.Dsm.Service
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM service API.
    /// </summary>
    public class DsmServiceApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM service API.
        /// </summary>
        private const string DsmServiceApiName = "SYNO.DSM.Service";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmServiceApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmServiceApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmServiceApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of services on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the services to retrieve in the list of services.</param>
        /// <param name="limit">The number of services to retrieve in the list of services.</param>
        /// <returns>A list of services on the DSM system.</returns>
        public async Task<DsmServiceCollection> List(int? offset, int? limit)
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
                DsmServiceApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmServiceCollection = JsonConvert.DeserializeObject<DsmServiceCollection>(response.Data.ToString());
            return dsmServiceCollection;
        }
    }
}
