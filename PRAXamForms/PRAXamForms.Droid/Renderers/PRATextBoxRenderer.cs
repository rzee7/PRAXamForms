using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PRAXamForms;
using PRAXamForms.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PRATextBox), typeof(PRATextBoxRenderer))]
namespace PRAXamForms.Droid
{
    public class PRATextBoxRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.PRATextBox);
            }
        }
    }
}