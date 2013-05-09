namespace DsmWebApi.Core
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Information about an API.
    /// </summary>
    public class DsmApiInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmApiInfo"/> class.
        /// </summary>
        /// <param name="name">The name of the API.</param>
        /// <param name="path">The path of the API.</param>
        /// <param name="minVersion">The minimum version of the API.</param>
        /// <param name="maxVersion">The maximum version of the API.</param>
        public DsmApiInfo(string name, string path, int minVersion, int maxVersion)
        {
            this.Name = name;
            this.Path = path;
            this.MinVersion = minVersion;
            this.MaxVersion = maxVersion;
        }

        /// <summary>
        /// Gets the name of the API.
        /// </summary>
        public string Name { get; private set; }

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

        /// <summary>
        /// Creates a <see cref="DsmApiInfo"/> object from a JSON property returned from the Web API.
        /// </summary>
        /// <param name="jsonProperty">The JSON property to convert.</param>
        /// <returns>The <see cref="DsmApiInfo"/> created.</returns>
        public static DsmApiInfo ConvertFrom(JProperty jsonProperty)
        {
            string name = jsonProperty.Name;
            string path = jsonProperty.Value["path"].ToString();
            int minVersion = jsonProperty.Value["minVersion"].Value<int>();
            int maxVersion = jsonProperty.Value["maxVersion"].Value<int>();
            DsmApiInfo apiInfo = new DsmApiInfo(name, path, minVersion, maxVersion);
            return apiInfo;
        }
    }
}
