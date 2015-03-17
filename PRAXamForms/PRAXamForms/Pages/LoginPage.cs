using PRAXamForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class LoginPage : ContentPage
    {

        #region View Model

        public LoginViewModel ViewModel { get { return BindingContext as LoginViewModel; } }

        #endregion

        #region Constructor

        public LoginPage()
        {
            #region Binding Context

            BindingContext = ViewModel.UserModel;

            #endregion

            #region Set Few Properties on the Page

            Padding = new Thickness(20);
            Title = "Login";
            BindingContext = null;

            #endregion

            #region Using Triggers
            var emailValTrig = new EventTrigger();
            emailValTrig.Event = "TextChanged";
            emailValTrig.Actions.Add(new EmailValidationTrigger());

            //Password
            var passwordValTrig = new EventTrigger();
            passwordValTrig.Event = "TextChanged";
            passwordValTrig.Actions.Add(new EmptyTextValidation());

            #endregion

            #region Create some Entry controls to capture username and password.

            Entry loginInput = new Entry { Placeholder = "User Name" };
            loginInput.SetBinding(Entry.TextProperty, "UserName");
            loginInput.Triggers.Add(emailValTrig);

            Entry passwordInput = new Entry { IsPassword = true, Placeholder = "Password" };
            passwordInput.SetBinding(Entry.TextProperty, "Password");
            passwordInput.Triggers.Add(passwordValTrig);

            #endregion

            #region Create a button to login with

            Button loginButton = new Button
            {
                Text = "Login",
                BorderRadius = 5,
                TextColor = Color.White,
                BackgroundColor = Color.Gray
            };
            loginButton.SetBinding(BackgroundColorProperty, new Binding("LoginButtonColour"));

            var dataTrigger = new DataTrigger(typeof(Button));
            dataTrigger.Binding = new Binding("Text.Length", BindingMode.Default, source: loginInput);
            dataTrigger.Value = 0;
            dataTrigger.Setters.Add(new Setter { Property = Button.IsEnabledProperty, Value = false });
            loginButton.Triggers.Add(dataTrigger);

            #endregion

            #region Adding Controls to Stack Layout

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                          {
                              loginInput,
                              passwordInput,
                              loginButton
                          },
                Spacing = 10,
            };

            #endregion
        }

        #endregion
    }
}
