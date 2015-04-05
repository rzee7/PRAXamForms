using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using PRAXamForms.iOS;
using PRAXamForms;
using UIKit;

[assembly: ExportRenderer(typeof(PRALabel), typeof(PRALabelRenderer))]
namespace PRAXamForms.iOS
{
	public class PRALabelRenderer : LabelRenderer
	{
		public PRALabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Control.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle("bubble.png"));
			}
		}
	}
}

