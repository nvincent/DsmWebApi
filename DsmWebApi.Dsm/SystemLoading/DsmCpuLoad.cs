namespace DsmWebApi.Dsm.SystemLoading
{
    using Newtonsoft.Json;

    /// <summary>
    /// The CPU load of a DSM system.
    /// </summary>
    public class DsmCpuLoad
    {
        /// <summary>
        /// Gets or sets the percentage of CPU used by hardware interruption requests.
        /// </summary>
        [JsonProperty("hard_irq")]
        public double HardIrq { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU in idle mode.
        /// </summary>
        [JsonProperty("idle")]
        public double Idle { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU waiting for IO.
        /// </summary>
        [JsonProperty("iowait")]
        public double IOWait { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU used by ???.
        /// TODO : Check the meaning of this value.
        /// </summary>
        [JsonProperty("nice")]
        public double Nice { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU used by software interruption requests.
        /// </summary>
        [JsonProperty("soft_irq")]
        public double SoftIrq { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU used by the Virtual Machine hypervisor.
        /// </summary>
        [JsonProperty("steal")]
        public double Steal { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU in system mode.
        /// </summary>
        [JsonProperty("system")]
        public double System { get; set; }

        /// <summary>
        /// Gets or sets the percentage of CPU in user mode.
        /// </summary>
        [JsonProperty("user")]
        public double User { get; set; }
    }
}
