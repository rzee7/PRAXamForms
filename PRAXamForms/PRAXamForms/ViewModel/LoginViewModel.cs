using PRAXamForms.Core;
using PRAXamForms.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PRAXamForms.ViewModel
{
    public class LoginViewModel : BaseListViewModel<MemberInfo>
    {
        public LoginViewModel()
        {
            UserModel = new UserInfo();

            SelectionChangedCommand = new Command(async () =>
            {
                await MemberService.PostData<Response, UserInfo>(MemberService.Login, HttpMethod.Post, UserModel).ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        Navigation.PushAsync(new ProfilePage() { BindingContext = t.Result.Members[0] }, true);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        private UserInfo _userModel;

        public UserInfo UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged("UserModel"); }
        }

        #region Register Command

        private ICommand _registerCommand;

        public ICommand RegisterCommand
        {
            get { return _registerCommand ?? (_registerCommand = new Command(async (param) => { await ExecuteRegisterUser(); })); }
        }

        private async Task ExecuteRegisterUser()
        {
            await MemberService.PostData<int, UserInfo>(MemberService.MemberList, HttpMethod.Post, UserModel).ContinueWith(t =>
            {
                if (!t.IsFaulted && t.Result > 0)
                {
                    Navigation.PushAsync(new DashboardPage() { BindingContext = UserModel }, true);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion
    }
}
