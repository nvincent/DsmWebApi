namespace DsmWebApi.Dsm.Service
{
    using Newtonsoft.Json;

    /// <summary>
    /// A service on a DSM system.
    /// </summary>
    public class DsmService
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
