using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PRAXamForms.Core
{
    public class UserInfo : BaseModel
    {
        #region Properties

        private string _userName;//="rzee.m7@gmail.com";

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; OnPropertyChanged("UserName");
                if (IsEmailValid(_userName))
                {
                    ProfileImage = MemberInfo.GenerateGravitarLink(UserName);
                }
            }
        }

        public static bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        private string _password="admin";

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value; OnPropertyChanged("Password");
            }
        }

        private string _profileImage;

        public string ProfileImage
        {
            get { return _profileImage; }
            set
            {
                _profileImage = value; OnPropertyChanged("ProfileImage");
            }
        }


        public bool IsActive { get; set; }

        #endregion
    }
}
