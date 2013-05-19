namespace DsmWebApi.Core
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Generic form of the response of the DSM Web API.
    /// </summary>
    public class DsmApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiResponse"/> class.
        /// </summary>
        /// <param name="data">The data of the response.</param>
        public DsmApiResponse(JToken data)
        {
            this.Data = data;
            this.Success = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiResponse"/> class.
        /// </summary>
        /// <param name="errorCode">The error code of the response.</param>
        public DsmApiResponse(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the data of the response when <see cref="Success"/> is true.
        /// </summary>
        /// <value>Always null when <see cref="Success"/> is false.</value>
        public JToken Data { get; private set; }

        /// <summary>
        /// Gets the error code of the response when <see cref="Success"/> is false.
        /// </summary>
        /// <value>Always null when <see cref="Success"/> is true.</value>
        public int? ErrorCode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the request was executed successfully.
        /// </summary>
        public bool Success { get; private set; }
    }
}
