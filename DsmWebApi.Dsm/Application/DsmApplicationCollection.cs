namespace DsmWebApi.Dsm.Application
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of applications on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmApplicationCollection : IEnumerable<DsmApplication>
    {
        /// <summary>
        /// The collection of queried applications.
        /// </summary>
        [JsonProperty("applications")]
        private IEnumerable<DsmApplication> applications = null;

        /// <summary>
        /// Gets or sets the offset of the <see cref="Applications"/> collection in the collection of all applications.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the total number of applications on the DSM system.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <inheritdoc />
        public IEnumerator<DsmApplication> GetEnumerator()
        {
            return this.applications.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.applications.GetEnumerator();
        }
    }
}
