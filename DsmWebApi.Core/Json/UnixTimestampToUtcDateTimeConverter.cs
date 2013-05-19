namespace DsmWebApi.Core.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JSON converter that converts integer values representing an UNIX timestamp to a UTC <see cref="DateTime"/> object.
    /// </summary>
    public class UnixTimestampToUtcDateTimeConverter : JsonConverter
    {
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            long? seconds = reader.Value as long?;
            if (seconds.HasValue)
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds.Value);
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
