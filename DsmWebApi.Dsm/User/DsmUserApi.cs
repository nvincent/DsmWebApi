namespace DsmWebApi.Dsm.User
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM user API.
    /// </summary>
    public class DsmUserApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM user API.
        /// </summary>
        private const string DsmUserApiName = "SYNO.DSM.User";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmUserApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmUserApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmUserApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of users on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the users to retrieve in the list of users.</param>
        /// <param name="limit">The number of users to retrieve in the list of users.</param>
        /// <returns>A list of users on the DSM system.</returns>
        public async Task<DsmUserCollection> List(int? offset, int? limit)
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
                DsmUserApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmUserCollection = JsonConvert.DeserializeObject<DsmUserCollection>(response.Data.ToString());
            return dsmUserCollection;
        }
    }
}
