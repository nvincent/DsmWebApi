namespace DsmWebApi.Dsm.SystemLoading
{
    using Newtonsoft.Json;

    /// <summary>
    /// The memory load of a DSM system.
    /// </summary>
    public class DsmMemoryLoad
    {
        /// <summary>
        /// Gets or sets the amount of buffered memory of the system in kB.
        /// </summary>
        [JsonProperty("buffer")]
        public int Buffer { get; set; }

        /// <summary>
        /// Gets or sets the amount of cached memory of the system in kB.
        /// </summary>
        [JsonProperty("cached")]
        public int Cached { get; set; }

        /// <summary>
        /// Gets or sets the amount of free memory of the system in kB.
        /// </summary>
        [JsonProperty("free")]
        public int Free { get; set; }

        /// <summary>
        /// Gets or sets the amount of cached swap memory of the system in kB.
        /// </summary>
        [JsonProperty("swap_cached")]
        public int SwapCached { get; set; }

        /// <summary>
        /// Gets or sets the total size of the system's memory in kB.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
