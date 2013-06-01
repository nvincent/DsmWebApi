namespace DsmWebApi.Dsm.Service
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of services on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmServiceCollection : IEnumerable<DsmService>
    {
        /// <summary>
        /// The collection of queried services.
        /// </summary>
        [JsonProperty("services")]
        private IEnumerable<DsmService> services = null;

        /// <summary>
        /// Gets or sets the offset of the retrieved services collection.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of services on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmService> GetEnumerator()
        {
            return this.services.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.services.GetEnumerator();
        }
    }
}
