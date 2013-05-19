namespace DsmWebApi.Dsm.Volume
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of volumes on a DSM system.
    /// </summary>
    public class DsmVolumeCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Volumes"/> collection in the collection of all volumes.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of volumes on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried volumes.
        /// </summary>
        [JsonProperty("volumes")]
        public IEnumerable<DsmVolume> Volumes { get; set; }
    }
}
