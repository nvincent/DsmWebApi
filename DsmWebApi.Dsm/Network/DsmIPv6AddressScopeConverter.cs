namespace DsmWebApi.Dsm.Network
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JSON converter that converts a string representing a IPv6 address scope to a <see cref="DsmIPv6AddressScope"/> value.
    /// </summary>
    public class DsmIPv6AddressScopeConverter : JsonConverter
    {
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            string scope = reader.Value as string;
            if (!string.IsNullOrEmpty(scope))
            {
                switch (scope)
                {
                    case "global":
                        return DsmIPv6AddressScope.Global;
                    case "link":
                        return DsmIPv6AddressScope.Link;
                    default:
                        throw new JsonSerializationException("Invalid value of IPv6 scope : " + scope);
                }
            }

            return null;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
