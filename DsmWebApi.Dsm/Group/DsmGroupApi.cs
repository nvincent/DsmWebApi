namespace DsmWebApi.Dsm.Group
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM group API.
    /// </summary>
    public class DsmGroupApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM group API.
        /// </summary>
        private const string DsmGroupApiName = "SYNO.DSM.Group";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmGroupApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmGroupApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmGroupApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of groups on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the groups collection to query.</param>
        /// <returns>A list of groups on the DSM system.</returns>
        public async Task<DsmGroupCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmGroupApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmGroupCollection = JsonConvert.DeserializeObject<DsmGroupCollection>(response.Data.ToString());
            return dsmGroupCollection;
        }
    }
}
