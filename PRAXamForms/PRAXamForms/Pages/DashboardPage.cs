using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            var lbl = new Label() { XAlign = TextAlignment.Center, YAlign = TextAlignment.Center };
            lbl.SetBinding(Label.TextProperty, "UserName");
            Content = lbl;

            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
            };

            var memberList = new PRALabel
            {
                Text = "ML",
                HeightRequest = WidthRequest = 45
            };

            var memberDetails = new PRALabel
            {
                Text = "MD",
                HeightRequest = WidthRequest = 45
            };

            var profile = new PRALabel
            {
                Text = "P",
                HeightRequest = WidthRequest = 45
            };

            var aboutMe = new PRALabel
            {
                Text = "A",
                HeightRequest = WidthRequest = 45
            };


            var lbls = new List<PRALabel> { memberList, memberDetails, profile, aboutMe };
            var stackLayout = new StackLayout
           {
               HorizontalOptions = LayoutOptions.Fill,
               HeightRequest = 50,
               AnchorY = App.ScreenSize.Height - 80,
               Children = { new ControlGrid(70, lbls, 1) }
           };
            Content = stackLayout;
        }
    }
    public class ControlGrid : Grid
    {
        public ControlGrid(double boxSize, List<PRALabel> rows, int columns)
        {
            HeightRequest = WidthRequest = 70;
            for (var row = 0; row < rows.Count; row++)
                for (var column = 0; column < columns; column++)
                {
                    var box = new PRALabel
                    {
                        Text = rows[row].Text, //Color.FromRgb(row * 256 / rows, column * 256 / columns, 127),
                        WidthRequest = boxSize,
                        HeightRequest = boxSize,
                        XAlign = TextAlignment.Center,
                        YAlign = TextAlignment.Center
                    };
                    Children.Add(box, row, column);
                }
        }
    }
}
