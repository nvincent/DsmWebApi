namespace DsmWebApi.Dsm.Package
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of packages on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmPackageCollection : IEnumerable<DsmPackage>
    {
        /// <summary>
        /// The collection of queried packages.
        /// </summary>
        [JsonProperty("packages")]
        private IEnumerable<DsmPackage> packages = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved packages collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of packages on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmPackage> GetEnumerator()
        {
            return this.packages.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.packages.GetEnumerator();
        }
    }
}
