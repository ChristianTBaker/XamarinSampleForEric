using System;
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using HelloPrism.Controls;
using HelloPrism.Droid.Custom.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HelloPrism.Droid.Custom.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetRawInputType(InputTypes.TextVariationWebEmailAddress);
                Control.SetBackgroundColor(global::Android.Graphics.Color.ParseColor("#F5F5F5"));
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Transparent));
                Control.SetCursorVisible(true);

                if (Build.VERSION.SdkInt <= BuildVersionCodes.P)
                {
                    IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                    IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

                    JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.custom_cursor);
                }
                else
                {
                    Control.SetTextCursorDrawable(Resource.Drawable.custom_cursor);
                }


            }

        }
    }
}