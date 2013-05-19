namespace DsmWebApi.Dsm.Network
{
    using Newtonsoft.Json;

    /// <summary>
    /// An IPv4 address.
    /// </summary>
    public class DsmIPv6Address
    {
        /// <summary>
        /// Gets or sets the value of the IPv6 address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the length of prefix in the IPv6 address.
        /// </summary>
        [JsonProperty("prefix_length")]
        public int PrefixLength { get; set; }

        /// <summary>
        /// Gets or sets the scope of the IPv6 address.
        /// </summary>
        [JsonProperty("scope")]
        public DsmIPv6AddressScope Scope { get; set; }
    }
}
