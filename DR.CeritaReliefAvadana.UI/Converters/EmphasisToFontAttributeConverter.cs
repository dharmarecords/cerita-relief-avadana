namespace DR.CeritaReliefAvadana.UI.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class EmphasisToFontAttributeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? FontAttributes.Italic : FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
