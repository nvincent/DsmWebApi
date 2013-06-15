namespace DsmWebApi.WpfClient
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// Converts empty strings back to a null value.
    /// </summary>
    internal class EmptyStringToNullConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == (object)string.Empty)
            {
                return null;
            }

            return value;
        }
    }
}
