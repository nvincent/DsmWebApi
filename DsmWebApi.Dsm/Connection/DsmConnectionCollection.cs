namespace DsmWebApi.Dsm.Connection
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of connections on a DSM system.
    /// </summary>
    public class DsmConnectionCollection
    {
        /// <summary>
        /// Gets or sets the collection of queried connections.
        /// </summary>
        [JsonProperty("connections")]
        public IEnumerable<DsmConnection> Connections { get; set; }
    }
}
