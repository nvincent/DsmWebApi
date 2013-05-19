namespace DsmWebApi.Dsm.Package
{
    using Newtonsoft.Json;

    /// <summary>
    /// A package on a DSM system.
    /// </summary>
    public class DsmPackage
    {
        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the title of the package.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the package.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the package is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the version of the package.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the maintainer of the package.
        /// </summary>
        [JsonProperty("maintainer")]
        public string Maintainer { get; set; }
    }
}
