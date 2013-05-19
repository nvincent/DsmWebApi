namespace DsmWebApi.Dsm.SystemLoading
{
    using Newtonsoft.Json;

    /// <summary>
    /// The network load of an interface of a DSM system.
    /// </summary>
    public class DsmNetworkLoad
    {
        /// <summary>
        /// Gets or sets the name of the interface.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the speed at which the system is receiving data on the interface in B/s.
        /// </summary>
        [JsonProperty("receive")]
        public int Receive { get; set; }

        /// <summary>
        /// Gets or sets the speed at which the system is transmitting data on the interface in B/s.
        /// </summary>
        [JsonProperty("transmit")]
        public int Transmit { get; set; }
    }
}
