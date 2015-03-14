using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms.Core
{
    public class MemberInfo : BaseModel
    {
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Ignore] for local DB
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Title { get; set; }
        public string ProfileImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public char Gender { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }

        #endregion
    }
}
