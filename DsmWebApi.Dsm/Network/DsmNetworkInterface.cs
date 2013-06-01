namespace DsmWebApi.Dsm.Network
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A network interface on a DSM system.
    /// </summary>
    public class DsmNetworkInterface
    {
        /// <summary>
        /// Gets or sets the ID of the network interface.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the network interface.
        /// </summary>
        [JsonProperty("mac")]
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets the type of the network interface.
        /// </summary>
        [JsonProperty("type")]
        public string NetworkInterfaceType { get; set; }

        /// <summary>
        /// Gets or sets the collection of all IPv4 addresses of the network interfaces.
        /// </summary>
        [JsonProperty("ip")]
        public IEnumerable<DsmIPv4Address> IPv4Addresses { get; set; }

        /// <summary>
        /// Gets or sets the collection of all IPv6 addresses of the network interfaces.
        /// </summary>
        [JsonProperty("ipv6")]
        public IEnumerable<DsmIPv6Address> IPv6Addresses { get; set; }
    }
}
