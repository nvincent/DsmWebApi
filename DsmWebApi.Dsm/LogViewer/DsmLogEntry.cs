namespace DsmWebApi.Dsm.LogViewer
{
    using System;
    using DsmWebApi.Core.Json;
    using Newtonsoft.Json;

    /// <summary>
    /// A log entry on a DSM system.
    /// </summary>
    public class DsmLogEntry
    {
        /// <summary>
        /// Gets or sets the log level of the entry.
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the message of the log entry.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the log entry.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixTimestampToUtcDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the user of the log entry.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }
    }
}
