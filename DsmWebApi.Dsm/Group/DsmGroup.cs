namespace DsmWebApi.Dsm.Group
{
    using Newtonsoft.Json;

    /// <summary>
    /// A group on a DSM system.
    /// </summary>
    public class DsmGroup
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
