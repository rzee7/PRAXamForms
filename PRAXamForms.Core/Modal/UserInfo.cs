using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRAXamForms.Core
{
    public class UserInfo : BaseModel
    {
        #region Properties

        private string _userName="rzee.m7@gmail.com";

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; OnPropertyChanged("UserName");
            }
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


        public bool IsActive { get; set; }

        #endregion
    }
}
