namespace DR.CeritaReliefAvadana.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using Xamarin.Forms;

    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var asm = GetType().GetTypeInfo().Assembly;
            return ImageSource.FromResource($"{asm.GetName().Name}.{parameter}.{value}", asm);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
