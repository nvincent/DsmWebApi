namespace DsmWebApi.Core
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Context used to access the API of a DSM system.
    /// </summary>
    public interface IDsmApiContext
    {
        /// <summary>
        /// Sends a request to a DSM API.
        /// </summary>
        /// <param name="apiPath">The path of the API.</param>
        /// <param name="api">The name of the API.</param>
        /// <param name="version">The version of the API.</param>
        /// <param name="method">The requested method of the API.</param>
        /// <param name="additionalParameters">Additional parameters of the request.</param>
        /// <returns>The response of the API.</returns>
        DsmApiResponse Request(string apiPath, string api, int version, string method, IDictionary<string, string> additionalParameters);

        /// <summary>
        /// Gets information about all available APIs.
        /// </summary>
        /// <returns>Information about all available APIs.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "The method can perform a time-consuming operation. The method can be perceivably slower than the time that is required to set or get the value of a field.")]
        IEnumerable<DsmApiInfo> GetAllApiInfo();
    }
}
