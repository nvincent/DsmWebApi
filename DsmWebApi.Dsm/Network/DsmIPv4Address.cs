namespace DsmWebApi.Dsm.Network
{
    using Newtonsoft.Json;

    /// <summary>
    /// An IPv4 address.
    /// </summary>
    public class DsmIPv4Address
    {
        /// <summary>
        /// Gets or sets the value of the IPv4 address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the network mask of the IPv4 address.
        /// </summary>
        [JsonProperty("netmask")]
        public string Mask { get; set; }
    }
}
