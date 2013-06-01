namespace DsmWebApi.Core
{
    using System;
    using DsmWebApi.Core.Json;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM encryption information returned by the DSM encryption API.
    /// </summary>
    public class EncryptionInformation
    {
        /// <summary>
        /// Gets or sets the cipher key.
        /// </summary>
        [JsonProperty("cipherkey")]
        public string CipherKey { get; set; }

        /// <summary>
        /// Gets or sets the cipher token.
        /// </summary>
        [JsonProperty("ciphertoken")]
        public string CipherToken { get; set; }

        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets UTC date and time on the server.
        /// </summary>
        [JsonProperty("server_time")]
        [JsonConverter(typeof(UnixTimestampToUtcDateTimeConverter))]
        public DateTime ServerTime { get; set; }
    }
}
