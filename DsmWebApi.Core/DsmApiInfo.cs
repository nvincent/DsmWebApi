namespace DsmWebApi.Core
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information about an API.
    /// </summary>
    public class DsmApiInfo
    {
        /// <summary>
        /// Gets or sets the path of the API.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the minimum version of the API.
        /// </summary>
        [JsonProperty("minVersion")]
        public int MinVersion { get; set; }

        /// <summary>
        /// Gets or sets the maximum version of the API.
        /// </summary>
        [JsonProperty("maxVersion")]
        public int MaxVersion { get; set; }
    }
}
