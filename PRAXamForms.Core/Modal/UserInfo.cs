using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRAXamForms.Core
{
    public class UserInfo : BaseModel
    {
        #region Properties

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
