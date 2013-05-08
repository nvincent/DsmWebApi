namespace DsmWebApi.Core
{
    /// <summary>
    /// Information about an API.
    /// </summary>
    public class DsmApiInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiInfo"/> class.
        /// </summary>
        /// <param name="path">The path of the API.</param>
        /// <param name="minVersion">The minimum version of the API.</param>
        /// <param name="maxVersion">The maximum version of the API.</param>
        public DsmApiInfo(string path, int minVersion, int maxVersion)
        {
            this.Path = path;
            this.MinVersion = minVersion;
            this.MaxVersion = maxVersion;
        }

        /// <summary>
        /// Gets the path of the API.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the minimum version of the API.
        /// </summary>
        public int MinVersion { get; private set; }

        /// <summary>
        /// Gets the maximum version of the API.
        /// </summary>
        public int MaxVersion { get; private set; }
    }
}
