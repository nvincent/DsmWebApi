namespace DsmWebApi.Dsm.Connection
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of connections on a DSM system.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DsmConnectionCollection : IEnumerable<DsmConnection>
    {
        /// <summary>
        /// The collection of queried connections.
        /// </summary>
        [JsonProperty("connections")]
        private IEnumerable<DsmConnection> connections = null;

        /// <inheritdoc />
        public IEnumerator<DsmConnection> GetEnumerator()
        {
            return this.connections.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.connections.GetEnumerator();
        }
    }
}
