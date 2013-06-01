namespace DsmWebApi.Dsm.Volume
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of volumes on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmVolumeCollection : IEnumerable<DsmVolume>
    {
        /// <summary>
        /// The collection of queried volumes.
        /// </summary>
        [JsonProperty("volumes")]
        private IEnumerable<DsmVolume> volumes = null;

        /// <summary>
        /// Gets or sets the offset of the <see cref="volumes"/> collection in the collection of all volumes.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of volumes on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmVolume> GetEnumerator()
        {
            return this.volumes.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.volumes.GetEnumerator();
        }
    }
}
