namespace DsmWebApi.Core.Json
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// JSON converter that converts integer values representing a duration in seconds to a <see cref="TimeSpan"/> object.
    /// </summary>
    public class SecondsToTimeSpanConverter : JsonConverter
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
                return TimeSpan.FromSeconds(seconds.Value);
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
