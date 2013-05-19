namespace DsmWebApi.Dsm.AutoBlock
{
    using Newtonsoft.Json;

    /// <summary>
    /// The auto block configuration of a DSM system.
    /// </summary>
    public class DsmAutoBlockConfiguration
    {
        /// <summary>
        /// Gets or sets the time period in minutes in which too many failed login attempts blocks the address.
        /// The value should be 0 to disable auto block.
        /// </summary>
        [JsonProperty("attemptmin")]
        public int AttemptsPeriod { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts to reach before blocking the address.
        /// The value should be 0 to disable auto block.
        /// </summary>
        [JsonProperty("attempts")]
        public int Attempts { get; set; }

        /// <summary>
        /// Gets or sets the number of days after which the block expires.
        /// The value should be 0 to disable block expiration.
        /// </summary>
        [JsonProperty("expiredday")]
        public int ExpiredDay { get; set; }
    }
}
