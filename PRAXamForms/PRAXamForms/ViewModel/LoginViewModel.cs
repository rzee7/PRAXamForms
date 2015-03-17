using PRAXamForms.Core;
using PRAXamForms.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms.ViewModel
{
    public class LoginViewModel : BaseListViewModel<MemberInfo>
    {
        public LoginViewModel()
        {
            MemberService.PostData<Response, UserInfo>(MemberService.Login, HttpMethod.Post, UserModel).ContinueWith(t =>
            {
                if (t.Result != null && t.Result.Members != null)
                    MemberData = t.Result.Members[0];
            }); ;
        }

        private UserInfo _userModel;

        public UserInfo UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged("UserModel"); }
        }

        private MemberInfo _memberData;

        public MemberInfo MemberData
        {
            get { return _memberData; }
            set { _memberData = value; OnPropertyChanged("MemberData"); }
        }
    }
}
