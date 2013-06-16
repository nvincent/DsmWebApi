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
        /// <param name="offset">The offset of the volumes to retrieve in the list of volumes.</param>
        /// <param name="limit">The number of volumes to retrieve in the list of volumes.</param>
        /// <returns>A list of volumes on the DSM system.</returns>
        public async Task<DsmVolumeCollection> List(int? offset, int? limit)
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
                DsmVolumeApiName,
                this.ApiInfo.MaxVersion,
                "list",
                parameters);
            var dsmVolumeCollection = JsonConvert.DeserializeObject<DsmVolumeCollection>(response.Data.ToString());
            return dsmVolumeCollection;
        }
    }
}
