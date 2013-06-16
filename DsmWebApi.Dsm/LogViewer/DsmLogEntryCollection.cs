namespace DsmWebApi.Dsm.LogViewer
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of log entries on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmLogEntryCollection : IEnumerable<DsmLogEntry>
    {
        /// <summary>
        /// The collection of queried log entries.
        /// </summary>
        [JsonProperty("logs")]
        private IEnumerable<DsmLogEntry> logEntries = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved log entries collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of log entries on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmLogEntry> GetEnumerator()
        {
            return this.logEntries.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.logEntries.GetEnumerator();
        }
    }
}
