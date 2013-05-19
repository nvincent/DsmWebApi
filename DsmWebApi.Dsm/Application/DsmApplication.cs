namespace DsmWebApi.Dsm.Application
{
    using Newtonsoft.Json;

    /// <summary>
    /// An application on a DSM system.
    /// </summary>
    public class DsmApplication
    {
        /// <summary>
        /// Gets or sets the ID of the application.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
