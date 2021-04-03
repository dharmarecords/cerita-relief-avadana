namespace DR.CeritaReliefAvadana.Core.Converters
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using DR.CeritaReliefAvadana.Core.Models;
    using MvvmCross.Converters;

    public sealed class LocalizedStringValueConverter : MvxValueConverter<LocalizedString, string>
    {
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Scope = "Method", MessageId = "0", Justification = "Passing null is supported.")]
        protected override string Convert(LocalizedString value, Type targetType, object parameter, CultureInfo culture)
        {
            return culture.TwoLetterISOLanguageName.Equals("en", StringComparison.OrdinalIgnoreCase)
                ? value.En
                : value.Id;
        }
    }
}
