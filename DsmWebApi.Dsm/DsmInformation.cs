namespace DsmWebApi.Dsm
{
    using System;
    using DsmWebApi.Core.Json;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM system information returned by the DSM information API.
    /// </summary>
    public class DsmInformation
    {
        /// <summary>
        /// Gets or sets the model of the hardware.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory installed on the hardware (in MB).
        /// </summary>
        [JsonProperty("ram")]
        public int MemoryInstalled { get; set; }

        /// <summary>
        /// Gets or sets the serial of the hardware.
        /// </summary>
        [JsonProperty("serial")]
        public string Serial { get; set; }

        /// <summary>
        /// Gets or sets the temperature of the system.
        /// </summary>
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the temperature warning is active.
        /// </summary>
        [JsonProperty("temperature_warn")]
        public bool TemperatureWarning { get; set; }

        /// <summary>
        /// Gets or sets the date and time defined on the system.
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(DsmFormatDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the uptime of the system.
        /// </summary>
        [JsonProperty("uptime")]
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan Uptime { get; set; }

        /// <summary>
        /// Gets or sets the version number of the system.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version string of the system.
        /// </summary>
        [JsonProperty("version_string")]
        public string VersionString { get; set; }
    }
}
