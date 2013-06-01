namespace DsmWebApi.Dsm.User
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of users on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmUserCollection : IEnumerable<DsmUser>
    {
        /// <summary>
        /// The collection of queried users.
        /// </summary>
        [JsonProperty("users")]
        private IEnumerable<DsmUser> users = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved users collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of users on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmUser> GetEnumerator()
        {
            return this.users.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.users.GetEnumerator();
        }
    }
}
