namespace DsmWebApi.Dsm.SystemLoading
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The system load of a DSM system.
    /// </summary>
    public class DsmSystemLoad
    {
        /// <summary>
        /// Gets or sets the CPU load of the DSM system.
        /// </summary>
        [JsonProperty("cpu")]
        public DsmCpuLoad CpuLoad { get; set; }

        /// <summary>
        /// Gets or sets the memory load of the DSM system.
        /// </summary>
        [JsonProperty("memory")]
        public DsmMemoryLoad MemoryLoad { get; set; }

        /// <summary>
        /// Gets or sets the network load by interface of the DSM system.
        /// </summary>
        [JsonProperty("netflows")]
        public IEnumerable<DsmNetworkLoad> NetworkLoads { get; set; }
    }
}
