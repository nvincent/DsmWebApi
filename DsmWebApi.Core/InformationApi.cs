namespace DsmWebApi.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The core information API.
    /// </summary>
    public class InformationApi : DsmApiBase
    {
        /// <summary>
        /// The name of the information API.
        /// </summary>
        private const string InformationApiName = "SYNO.API.Info";

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public InformationApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, InformationApiName, 1)
        {
        }

        /// <summary>
        /// Gets the information about all available APIs.
        /// </summary>
        /// <returns>The information about all available APIs.</returns>
        public IEnumerable<DsmApiInfo> QueryAll()
        {
            DsmApiResponse response = this.ApiContext.Request(
                this.ApiInfo.Path,
                InformationApiName,
                this.ApiInfo.MaxVersion,
                "query",
                new Dictionary<string, string>()
                {
                    { "query", "all" }
                });

            var allApiInfo = response.Data
                                     .Children()
                                     .OfType<JProperty>()
                                     .Select(p => DsmApiInfo.ConvertFrom(p));
            return allApiInfo;
        }
    }
}
