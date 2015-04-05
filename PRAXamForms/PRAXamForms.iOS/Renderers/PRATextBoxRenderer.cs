using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PRAXamForms;
using PRAXamForms.iOS;

[assembly: ExportRenderer(typeof(PRATextBox), typeof(PRATextBoxRenderer))]
namespace PRAXamForms.iOS
{

	public class PRATextBoxRenderer : EntryRenderer
	{
		public PRATextBoxRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

		}
	}
}

