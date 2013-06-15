namespace DsmWebApi.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Context used to access the API of a DSM system.
    /// </summary>
    public interface IDsmApiContext
    {
        /// <summary>
        /// Gets information about all available APIs.
        /// </summary>
        IDictionary<string, DsmApiInfo> AllApiInfo { get; }

        /// <summary>
        /// Loads information about all available APIs.
        /// </summary>
        /// <returns>The task that loads all available APIs.</returns>
        Task LoadAllApiInfo();

        /// <summary>
        /// Sends a request to a DSM API.
        /// </summary>
        /// <param name="apiPath">The path of the API.</param>
        /// <param name="api">The name of the API.</param>
        /// <param name="version">The version of the API.</param>
        /// <param name="method">The requested method of the API.</param>
        /// <param name="additionalParameters">Additional parameters of the request.</param>
        /// <returns>The response of the API.</returns>
        Task<DsmApiResponse> Request(string apiPath, string api, int version, string method, IDictionary<string, string> additionalParameters);
    }
}
