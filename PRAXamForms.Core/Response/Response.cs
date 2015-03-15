using PRAXamForms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms
{
    /// <summary>
    /// API Response 
    /// </summary>
    public class Response
    {
        #region Constructor

        public Response()
        {
            Members = new List<MemberInfo>();
        }

        #endregion

        #region Properties

        public IList<MemberInfo> Members { get; set; }
        public string Error { get; set; }
        public bool Success { get { return string.IsNullOrEmpty(Error); } }

        #endregion
    }
}
