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
        /// <param name="offset">The offset of the services collection to query.</param>
        /// <returns>A list of services on the DSM system.</returns>
        public async Task<DsmServiceCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmServiceApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmServiceCollection = JsonConvert.DeserializeObject<DsmServiceCollection>(response.Data.ToString());
            return dsmServiceCollection;
        }
    }
}
