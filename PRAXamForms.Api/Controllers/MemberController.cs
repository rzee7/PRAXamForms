using PRAXamForms.Core;
using PRAXamForms.Data.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRAXamForms.Api.Controllers
{
    public class MemberController : ApiController
    {
        // GET api/mamber
        public Response Get()
        {
            return BLMemberInfo.Instance.GetMembers(-1); // -1 to get all members
        }

        // GET api/mamber/5
        public Response Get(int id)
        {
            return BLMemberInfo.Instance.GetMembers(id);
        }

        // POST api/mamber
        public int Post([FromBody]UserInfo _userInfo)
        {
            return BLMemberInfo.Instance.RegisterUser(_userInfo);
        }

        // PUT api/mamber/5
        public int Put(int id, [FromBody]MemberInfo _memberInfo)
        {
            return BLMemberInfo.Instance.AddUpdateMember(_memberInfo);
        }

        // DELETE api/mamber/5
        public void Delete(int id)
        {
        }
    }
}
