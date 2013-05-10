namespace DsmWebApi.Core.Json
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// JSON converter that converts a string into a <see cref="DateTime"/> with the format used by the DSM system.
    /// </summary>
    public class DsmFormatDateTimeConverter : DateTimeConverterBase
    {
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            string value = reader.Value.ToString();
            var dateTimeValue = DateTime.ParseExact(value, "ddd MMM d HH:mm:ss yyyy", CultureInfo.CurrentCulture);
            return dateTimeValue;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
