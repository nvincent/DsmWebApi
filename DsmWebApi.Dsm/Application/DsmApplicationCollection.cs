namespace DsmWebApi.Dsm.Application
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of applications on a DSM system.
    /// </summary>
    public class DsmApplicationCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Applications"/> collection in the collection of all applications.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of applications on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried applications.
        /// </summary>
        [JsonProperty("applications")]
        public IEnumerable<DsmApplication> Applications { get; set; }
    }
}
