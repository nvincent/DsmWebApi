namespace DsmWebApi.Dsm.Network
{
    using Newtonsoft.Json;

    /// <summary>
    /// Scope of an IPv6 address.
    /// </summary>
    [JsonConverter(typeof(DsmIPv6AddressScopeConverter))]
    public enum DsmIPv6AddressScope
    {
        /// <summary>
        /// IPv6 global scope.
        /// </summary>
        Global,

        /// <summary>
        /// IPv6 link scope.
        /// </summary>
        Link
    }
}
