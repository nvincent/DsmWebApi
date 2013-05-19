namespace DsmWebApi.Dsm.AutoBlock
{
    using System;
    using DsmWebApi.Core.Json;
    using Newtonsoft.Json;

    /// <summary>
    /// An address blocked by Auto Block.
    /// </summary>
    public class DsmBlockedAddress
    {
        /// <summary>
        /// Gets or sets the blocked IP address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time at which the address was block.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixTimestampToDateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
