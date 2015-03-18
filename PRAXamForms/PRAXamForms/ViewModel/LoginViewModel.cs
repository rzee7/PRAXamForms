using PRAXamForms.Core;
using PRAXamForms.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
                        Navigation.PushAsync(new ProfilePage(t.Result.Members[0]),true);
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

    }
}
