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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PRAXamForms.Droid;
using PRAXamForms;
using Android.Graphics;

[assembly: ExportRenderer(typeof(PRALabel), typeof(PRALabelRenderer))]
namespace PRAXamForms.Droid
{
    public class PRALabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.bubble);
            }
        }
        //protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        //{
        //    var radius = Math.Min(Width, Height) / 2;
        //    var strokeWidth = 10;
        //    radius -= strokeWidth / 2;

        //    Path path = new Path();
        //    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
        //    canvas.Save();
        //    canvas.ClipPath(path);

        //    var result = base.DrawChild(canvas, child, drawingTime);

        //    canvas.Restore();

        //    path = new Path();
        //    path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

        //    var paint = new Paint();
        //    paint.AntiAlias = true;
        //   // paint.StrokeWidth = ((ImageCircle.Forms.Plugin.Abstractions.CircleImage)Element).BorderThickness;
        //    paint.SetStyle(Paint.Style.Stroke);
        //   // paint.Color = ((ImageCircle.Forms.Plugin.Abstractions.CircleImage)Element).BorderColor.ToAndroid();

        //    canvas.DrawPath(path, paint);

        //    paint.Dispose();
        //    path.Dispose();
        //    return result;

        //}
    }
}