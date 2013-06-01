namespace DsmWebApi.Dsm.SystemLoading
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM system loading API.
    /// </summary>
    public class DsmSystemLoadingApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM system loading API.
        /// </summary>
        private const string DsmSystemLoadingApiName = "SYNO.DSM.SystemLoading";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmSystemLoadingApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmSystemLoadingApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmSystemLoadingApiName, 1)
        {
        }

        /// <summary>
        /// Gets the information about the system load.
        /// </summary>
        /// <returns>The information about the system load.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "The method can perform a time-consuming operation. The method can be perceivably slower than the time that is required to set or get the value of a field.")]
        public async Task<DsmSystemLoad> GetInfo()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmSystemLoadingApiName,
                this.ApiInfo.MaxVersion,
                "getinfo",
                null);
            var dsmSystemLoad = JsonConvert.DeserializeObject<DsmSystemLoad>(response.Data.ToString());
            return dsmSystemLoad;
        }
    }
}
