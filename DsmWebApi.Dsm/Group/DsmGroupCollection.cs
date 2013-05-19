namespace DsmWebApi.Dsm.Group
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of groups on a DSM system.
    /// </summary>
    public class DsmGroupCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Groups"/> collection in the collection of all groups.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of groups on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried groups.
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<DsmGroup> Groups { get; set; }
    }
}
