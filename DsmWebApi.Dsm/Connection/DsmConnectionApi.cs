namespace DsmWebApi.Dsm.Connection
{
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM connection API.
    /// </summary>
    public class DsmConnectionApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM connection API.
        /// </summary>
        private const string DsmConnectionApiName = "SYNO.DSM.Connection";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmConnectionApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmConnectionApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmConnectionApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of connections on the DSM system.
        /// </summary>
        /// <returns>A list of connections on the DSM system.</returns>
        public async Task<DsmConnectionCollection> List()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmConnectionApiName,
                this.ApiInfo.MaxVersion,
                "list",
                null);
            var dsmConnectionCollection = JsonConvert.DeserializeObject<DsmConnectionCollection>(response.Data.ToString());
            return dsmConnectionCollection;
        }
    }
}
