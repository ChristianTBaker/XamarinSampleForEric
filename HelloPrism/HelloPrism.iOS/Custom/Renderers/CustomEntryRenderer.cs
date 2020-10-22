using HelloPrism.Controls;
using HelloPrism.iOS.Custom.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using EntryRenderer = Xamarin.Forms.Platform.iOS.EntryRenderer;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HelloPrism.iOS.Custom.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Clear;
                Control.BorderStyle = UITextBorderStyle.None;
                Control.KeyboardType = UIKeyboardType.EmailAddress;
                Control.TintColor = UIColor.Black;
            }
        }
    }
}