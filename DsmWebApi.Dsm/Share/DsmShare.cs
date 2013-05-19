namespace DsmWebApi.Dsm.Share
{
    using Newtonsoft.Json;

    /// <summary>
    /// A share on a DSM system.
    /// </summary>
    public class DsmShare
    {
        /// <summary>
        /// Gets or sets the name of the share.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the share.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status of the share.
        /// </summary>
        [JsonProperty("status")]
        public DsmShareStatus Status { get; set; }
    }
}
