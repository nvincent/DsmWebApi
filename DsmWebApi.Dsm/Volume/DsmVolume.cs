namespace DsmWebApi.Dsm.Volume
{
    using Newtonsoft.Json;

    /// <summary>
    /// A volume on a DSM system.
    /// </summary>
    public class DsmVolume
    {
        /// <summary>
        /// Gets or sets the ID of the volume.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the status of the volume.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the total capacity of the volume in kB.
        /// </summary>
        [JsonProperty("total")]
        public double TotalCapacity { get; set; }

        /// <summary>
        /// Gets or sets the used space of the volume in kB.
        /// </summary>
        [JsonProperty("used")]
        public double UsedSpace { get; set; }
    }
}
