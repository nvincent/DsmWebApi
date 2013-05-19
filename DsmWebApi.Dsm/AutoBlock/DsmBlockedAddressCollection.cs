namespace DsmWebApi.Dsm.AutoBlock
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of blocked addresses on a DSM system.
    /// </summary>
    public class DsmBlockedAddressCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="BlockedAddresses"/> collection in the collection of all blocked addresses.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of blocked addresses on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried blocked addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public IEnumerable<DsmBlockedAddress> BlockedAddresses { get; set; }
    }
}
