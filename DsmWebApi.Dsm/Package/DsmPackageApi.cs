﻿namespace DsmWebApi.Dsm.Package
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// The DSM service API.
    /// </summary>
    public class DsmPackageApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM service API.
        /// </summary>
        private const string DsmPackageApiName = "SYNO.DSM.Package";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmPackageApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmPackageApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmPackageApiName, 1)
        {
        }

        /// <summary>
        /// Gets a list of packages on the DSM system.
        /// </summary>
        /// <param name="offset">The offset of the packages collection to query.</param>
        /// <returns>A list of packages on the DSM system.</returns>
        public async Task<DsmPackageCollection> List(int offset)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmPackageApiName,
                this.ApiInfo.MaxVersion,
                "list",
                new Dictionary<string, string>()
                {
                    { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                });
            var dsmPackageCollection = JsonConvert.DeserializeObject<DsmPackageCollection>(response.Data.ToString());
            return dsmPackageCollection;
        }
    }
}
