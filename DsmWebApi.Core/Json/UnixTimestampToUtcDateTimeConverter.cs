namespace DsmWebApi.Core.Json
{
    using System;

    /// <summary>
    /// JSON converter that converts integer values representing an UNIX timestamp to a UTC <see cref="DateTime"/> object.
    /// </summary>
    public class UnixTimestampToUtcDateTimeConverter : UnixTimestampToDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnixTimestampToUtcDateTimeConverter"/> class.
        /// </summary>
        public UnixTimestampToUtcDateTimeConverter()
        {
            this.Kind = DateTimeKind.Utc;
        }
    }
}
