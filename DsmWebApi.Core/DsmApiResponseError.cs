namespace DsmWebApi.Core
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error part of a DSM API response.
    /// </summary>
    public class DsmApiResponseError
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
