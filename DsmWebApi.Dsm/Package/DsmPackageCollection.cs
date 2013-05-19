namespace DsmWebApi.Dsm.Package
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of packages on a DSM system.
    /// </summary>
    public class DsmPackageCollection
    {
        /// <summary>
        /// Gets or sets the offset of the <see cref="Packages"/> collection in the collection of all packages.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of packages on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the collection of queried packages.
        /// </summary>
        [JsonProperty("packages")]
        public IEnumerable<DsmPackage> Packages { get; set; }
    }
}
