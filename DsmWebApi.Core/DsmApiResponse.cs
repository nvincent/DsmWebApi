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
        /// Gets the data of the response when <see cref="Success"/> is true.
        /// </summary>
        /// <value>Always null when <see cref="Success"/> is false.</value>
        [JsonProperty("data")]
        public JToken Data { get; private set; }

        /// <summary>
        /// Gets the error of the response when <see cref="Success"/> is false.
        /// </summary>
        /// <value>Always null when <see cref="Success"/> is true.</value>
        [JsonProperty("error")]
        public DsmApiResponseError Error { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the request was executed successfully.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; private set; }
    }
}
