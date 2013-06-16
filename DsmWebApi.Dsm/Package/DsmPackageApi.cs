namespace DsmWebApi.Dsm.Package
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM package API.
    /// </summary>
    public class DsmPackageApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM package API.
        /// </summary>
        private const string DsmPackageApiName = "SYNO.DSM.Package";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmPackageApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmPackageApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmPackageApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of packages on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the packages to retrieve in the list of packages.</param>
        /// <param name="limit">The number of packages to retrieve in the list of packages.</param>
        /// <returns>A list of packages on the DSM system.</returns>
        public async Task<DsmPackageCollection> List(int? offset, int? limit)
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
                DsmPackageApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmPackageCollection = JsonConvert.DeserializeObject<DsmPackageCollection>(response.Data.ToString());
            return dsmPackageCollection;
        }
    }
}
