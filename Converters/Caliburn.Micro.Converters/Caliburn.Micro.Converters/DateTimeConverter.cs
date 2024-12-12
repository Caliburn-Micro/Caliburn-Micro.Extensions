﻿using System.Globalization;
using System.Windows.Data;

namespace Caliburn.Micro.Converters
{
    /// <summary>
    /// Converts a DateTime value to a string.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>

    public class DateTimeConverter : IValueConverter
    {
        /// <summary>
        /// Converts a DateTime value to a string.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTimeValue)
            {
                string format = (parameter as string) ?? string.Empty;
                return (!string.IsNullOrEmpty(format)) ? dateTimeValue.ToString(format) : dateTimeValue.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts a string value back to a DateTime.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && decimal.TryParse(stringValue, NumberStyles.Any, culture, out decimal result))
            {
                return result;
            }
            return 0m;
        }
    }
}
