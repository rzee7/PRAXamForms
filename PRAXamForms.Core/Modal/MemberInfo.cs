using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBrainLab.Security.Cryptography;

namespace PRAXamForms.Core
{
    public class MemberInfo : BaseModel
    {
        public MemberInfo()
        {
            User = new UserInfo();
        }

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Ignore] for local DB
        //[Ignore]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Title { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public char Gender { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int UserID { get; set; }

        [JsonIgnore]
        public UserInfo User { get; set; }

        private string gravitar;
        public string Gravitar
        {
            get
            {
                if (string.IsNullOrEmpty(gravitar) && UserID > 100)
                {
                    gravitar = GenerateGravitarLink(User.UserName);
                }
                return gravitar;
            }
        }

        private string gravitarLarge;
        public string GravitarLarge
        {
            get
            {
                if (string.IsNullOrEmpty(ProfileImage))
                {
                    gravitarLarge = GenerateGravitarLink(User.UserName, 150);
                }
                return gravitarLarge;
            }
        }

        #endregion

        #region Gravitar

        public static string GenerateGravitarLink(string email, int size = -1)
        {
            email = email.Trim().ToLower();
            var hash = MD5.GetHashString(email);
            var gravitar = string.Empty;

            if (size > 0)
            {
                //show to size
                gravitar = string.Format("{0}{1}?s={2}",
                    "http://www.gravatar.com/avatar/",
                    hash.ToLower(), size);
            }
            else
            {
                gravitar = string.Format("{0}{1}",
                    "http://www.gravatar.com/avatar/",
                    hash.ToLower());
            }

            return gravitar;
        }

        #endregion
    }
}
