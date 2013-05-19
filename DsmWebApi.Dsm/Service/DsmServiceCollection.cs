namespace DsmWebApi.Dsm.Service
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of services on a DSM system.
    /// </summary>
    public class DsmServiceCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Services"/> collection in the collection of all services.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of services on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried services.
        /// </summary>
        [JsonProperty("services")]
        public IEnumerable<DsmService> Services { get; set; }
    }
}
