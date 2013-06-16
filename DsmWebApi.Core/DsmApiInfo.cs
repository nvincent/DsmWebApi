namespace DsmWebApi.Core
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information about an API.
    /// </summary>
    public class DsmApiInfo
    {
        /// <summary>
        /// Gets the path of the API.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets the minimum version of the API.
        /// </summary>
        [JsonProperty("minVersion")]
        public int MinVersion { get; set; }

        /// <summary>
        /// Gets the maximum version of the API.
        /// </summary>
        [JsonProperty("maxVersion")]
        public int MaxVersion { get; set; }
    }
}
