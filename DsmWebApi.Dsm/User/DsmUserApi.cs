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
        /// <param name="offset">The offset of the users collection to query.</param>
        /// <returns>A list of users on the DSM system.</returns>
        public async Task<DsmUserCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmUserApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmUserCollection = JsonConvert.DeserializeObject<DsmUserCollection>(response.Data.ToString());
            return dsmUserCollection;
        }
    }
}
