namespace DR.CeritaReliefAvadana.UI.Extensions
{
    using System;
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            var imageSource = ImageSource.FromResource($"{assembly.GetName().Name}.{Source}", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
