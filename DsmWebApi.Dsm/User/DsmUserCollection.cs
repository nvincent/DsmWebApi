namespace DsmWebApi.Dsm.User
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of users on a DSM system.
    /// </summary>
    public class DsmUserCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Users"/> collection in the collection of all users.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of users on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried users.
        /// </summary>
        [JsonProperty("users")]
        public IEnumerable<DsmUser> Users { get; set; }
    }
}
