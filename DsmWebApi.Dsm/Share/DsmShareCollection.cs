namespace DsmWebApi.Dsm.Share
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of shares on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmShareCollection : IEnumerable<DsmShare>
    {
        /// <summary>
        /// The collection of queried shares.
        /// </summary>
        [JsonProperty("shares")]
        private IEnumerable<DsmShare> shares = null;

        /// <summary>
        /// Gets or sets the offset of the <see cref="Shares"/> collection in the collection of all shares.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of shares on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmShare> GetEnumerator()
        {
            return this.shares.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.shares.GetEnumerator();
        }
    }
}
