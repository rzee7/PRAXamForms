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
            BindingContext=info;

            var lbl = new Label { HeightRequest = 30, WidthRequest = AbsoluteLayout.AutoSize, BackgroundColor=Color.Gray, TextColor=Color.Red };
            lbl.SetBinding(Label.TextProperty, "FullName");
            Content = new StackLayout { Children = { lbl }, HeightRequest=50 };
        }

        #endregion
    }
}
