namespace DsmWebApi.Core
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Generic form of the response of the DSM Web API.
    /// </summary>
    public class DsmApiResponse
    {
        /// <summary>
        /// Gets or sets the data of the response when <see cref="Success"/> is true.
        /// </summary>
        [JsonProperty("data")]
        public JToken Data { get; set; }

        /// <summary>
        /// Gets or sets the error of the response when <see cref="Success"/> is false.
        /// </summary>
        [JsonProperty("error")]
        public DsmApiResponseError Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the request was executed successfully.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
