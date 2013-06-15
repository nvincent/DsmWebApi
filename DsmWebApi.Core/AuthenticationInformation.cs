namespace DsmWebApi.Core
{
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM authentication information returned when logging on.
    /// </summary>
    public class AuthenticationInformation
    {
        /// <summary>
        /// Gets or sets the SID of the authenticated connection.
        /// </summary>
        [JsonProperty("sid")]
        public string SID { get; set; }
    }
}
