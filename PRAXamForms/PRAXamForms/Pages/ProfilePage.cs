using ImageCircle.Forms.Plugin.Abstractions;
using PRAXamForms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class ProfilePage : ContentPage
    {
        #region Constructor

        public ProfilePage(MemberInfo info)
        {
            #region  Main View

            BindingContext = info;

            BackgroundImage = "backImage";
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
            };

            #endregion

            #region Profile Image

            //Profile Image
            var CircleImage = new CircleImage
            {
                Source = "ProfileImage",
                BorderColor = Color.White,
                BorderThickness = 2,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            CircleImage.SetBinding(Image.SourceProperty, "ProfileImage");

            MainView.Children.Add(CircleImage, Constraint.Constant(10), Constraint.Constant(10),
               Constraint.RelativeToParent(parent => { return 120; }),
               Constraint.RelativeToParent(parent => { return 120; }));

            #endregion

            #region Text Label

            //Full Name
            var namelbl = new PRALabel { HeightRequest = 70, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, WidthRequest = 70, TextColor = Color.White };
            namelbl.SetBinding(Label.TextProperty, "FullName");

            MainView.Children.Add(namelbl, Constraint.RelativeToView(CircleImage, (parent, sibling) => { return sibling.Width + 30; }),
            Constraint.RelativeToView(CircleImage, (parent, sibling) => { return sibling.Height - 50; }), Constraint.Constant(100), Constraint.Constant(100));

            //Date of Birth
            var dateLbl = new PRALabel { HeightRequest = 70, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, WidthRequest = 70, TextColor = Color.White };
            dateLbl.SetBinding(Label.TextProperty, new Binding("DateOfBirth") { StringFormat = "Birth {0:dd MMM}" });

            MainView.Children.Add(dateLbl, Constraint.RelativeToView(CircleImage, (parent, sibling) => { return sibling.X + 25; }),
            Constraint.RelativeToView(namelbl, (parent, sibling) => { return sibling.Height + sibling.Y + 30; }), Constraint.Constant(100), Constraint.Constant(100));

            //Date of Joining
            var joiningLbl = new PRALabel { HeightRequest = 70, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, WidthRequest = 70, TextColor = Color.White };
            joiningLbl.SetBinding(Label.TextProperty, new Binding("DateOfJoining") { StringFormat = "Join {0:dd MMM}" });

            MainView.Children.Add(joiningLbl, Constraint.RelativeToView(namelbl, (parent, sibling) => { return sibling.X + 35; }),
            Constraint.RelativeToView(dateLbl, (parent, sibling) => { return sibling.Height + sibling.Y - 20; }), Constraint.Constant(100), Constraint.Constant(100));

            #endregion

            #region Social Icons

            var fbIcon = new CircleImage
            {
                Source = "fbIcon",
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var twtIcon = new CircleImage
            {
                Source = "twtIcon",
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var lkIcon = new CircleImage
            {
                Source = "lkIcon",
                BorderColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            //FB Icon
            MainView.Children.Add(fbIcon, Constraint.RelativeToView(CircleImage, (parent, sibling) => { return sibling.X + 10; }),
            Constraint.RelativeToView(dateLbl, (parent, sibling) => { return sibling.Height + sibling.Y + 20; }), Constraint.Constant(50), Constraint.Constant(50));

            //Twitter
            MainView.Children.Add(twtIcon, Constraint.RelativeToView(fbIcon, (parent, sibling) => { return sibling.X + 35; }),
            Constraint.RelativeToView(fbIcon, (parent, sibling) => { return sibling.Height + sibling.Y + 20; }), Constraint.Constant(50), Constraint.Constant(50));

            //Linkedin
            MainView.Children.Add(lkIcon, Constraint.RelativeToView(twtIcon, (parent, sibling) => { return sibling.X + 50; }),
            Constraint.RelativeToView(twtIcon, (parent, sibling) => { return sibling.Height + sibling.Y + 20; }), Constraint.Constant(50), Constraint.Constant(50));

            #endregion

            Content = MainView;
        }

        #endregion
    }
}
