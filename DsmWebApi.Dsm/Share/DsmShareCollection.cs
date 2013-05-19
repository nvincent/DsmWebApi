namespace DsmWebApi.Dsm.Share
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of shares on a DSM system.
    /// </summary>
    public class DsmShareCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Shares"/> collection in the collection of all shares.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of shares on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried shares.
        /// </summary>
        [JsonProperty("shares")]
        public IEnumerable<DsmShare> Shares { get; set; }
    }
}
