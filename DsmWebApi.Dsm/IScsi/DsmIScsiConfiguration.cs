namespace DsmWebApi.Dsm.IScsi
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// iSCSI configuration of a DSM system.
    /// </summary>
    public class DsmIScsiConfiguration
    {
        /// <summary>
        /// Gets or sets the collection of iSCSI LUNs.
        /// </summary>
        [JsonProperty("luns")]
        public IEnumerable<DsmIScsiLun> Luns { get; set; }

        /// <summary>
        /// Gets or sets the collection of iSCSI mappings.
        /// </summary>
        [JsonProperty("mappings")]
        public IEnumerable<DsmIScsiMapping> Mappings { get; set; }

        /// <summary>
        /// Gets or sets the collection of iSCSI targets.
        /// </summary>
        [JsonProperty("targets")]
        public IEnumerable<DsmIScsiTarget> Targets { get; set; }
    }
}
