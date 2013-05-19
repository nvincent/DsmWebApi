namespace DsmWebApi.Dsm.User
{
    using Newtonsoft.Json;

    /// <summary>
    /// A user on a DSM system.
    /// </summary>
    public class DsmUser
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the user.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
