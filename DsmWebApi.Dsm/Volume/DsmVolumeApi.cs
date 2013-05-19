namespace DsmWebApi.Dsm.Volume
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM volume API.
    /// </summary>
    public class DsmVolumeApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM volume API.
        /// </summary>
        private const string DsmVolumeApiName = "SYNO.DSM.Volume";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmVolumeApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmVolumeApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmVolumeApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of volumes on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the volumes collection to query.</param>
        /// <returns>A list of volumes on the DSM system.</returns>
        public async Task<DsmVolumeCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmVolumeApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmVolumeCollection = JsonConvert.DeserializeObject<DsmVolumeCollection>(response.Data.ToString());
            return dsmVolumeCollection;
        }
    }
}
