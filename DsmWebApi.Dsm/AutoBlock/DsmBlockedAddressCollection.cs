namespace DsmWebApi.Dsm.AutoBlock
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of blocked addresses on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmBlockedAddressCollection : IEnumerable<DsmBlockedAddress>
    {
        /// <summary>
        /// The collection of queried blocked addresses.
        /// </summary>
        [JsonProperty("addresses")]
        private IEnumerable<DsmBlockedAddress> blockedAddresses = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved blocked addresses collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of blocked addresses on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmBlockedAddress> GetEnumerator()
        {
            return this.blockedAddresses.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.blockedAddresses.GetEnumerator();
        }
    }
}
