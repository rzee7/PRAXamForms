using ImageCircle.Forms.Plugin.Abstractions;
using PRAXamForms.Core;
using PRAXamForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class RegisterPage : ContentPage
    {

        #region ViewModel

        public LoginViewModel ViewModel { get { return BindingContext as LoginViewModel; } }

        #endregion

        #region Constructor

        public RegisterPage()
        {
            BackgroundImage = "backImage";
            BindingContext = new LoginViewModel();
            var profileImage = new CircleImage
            {
                WidthRequest = 100,
                HeightRequest = 100,
                BorderThickness = 0,
                HorizontalOptions = LayoutOptions.Center
            };

            profileImage.SetBinding(CircleImage.SourceProperty, "UserModel.ProfileImage");

            var userExist = new EventTrigger();
            userExist.Event = "TextChanged";
            userExist.Actions.Add(new UserAvailabilityTrigger());

            var praTextBox = CreateEntryFor("Email", "UserModel.UserName");
            praTextBox.Triggers.Add(userExist);
            var mainLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(15, 0, 15, 0),
                Children = { profileImage, praTextBox, CreateEntryFor("Passowrd", "UserModel.Password",true)
                }
            };
            Content = mainLayout;
        }

        #endregion

        #region Grid

        private Grid ControlGrid()
        {
            var grid = new Grid
            {
                Padding = new Thickness(0, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 5,
                RowSpacing = 10,

            };
            grid.Children.Add(CreateEntryFor("First Name", "First Name"), 0, 0);
            grid.Children.Add(CreateEntryFor("Last Name", "Last Name"), 1, 0);
            return grid;
        }

        #endregion

        #region Entry Forms

        public Entry CreateEntryFor(string placeHolder, string bindingName, bool IsPassword = false)
        {
            PRATextBox praEditTextBox = new PRATextBox
            {
                TextColor = Color.White,
                IsPassword = IsPassword,
                Placeholder = placeHolder,
                BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
                TranslationY = 2,
                WidthRequest = App.ScreenSize.Width
            };
            praEditTextBox.HorizontalOptions = LayoutOptions.CenterAndExpand;
            praEditTextBox.SetBinding(PRATextBox.TextProperty, bindingName);
            return praEditTextBox;
        }
        #endregion
    }
}
