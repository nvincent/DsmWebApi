namespace DsmWebApi.Dsm.Group
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of groups on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmGroupCollection : IEnumerable<DsmGroup>
    {
        /// <summary>
        /// The collection of queried groups.
        /// </summary>
        [JsonProperty("groups")]
        private IEnumerable<DsmGroup> groups = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved groups collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of groups on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmGroup> GetEnumerator()
        {
            return this.groups.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.groups.GetEnumerator();
        }
    }
}
