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
    public class LoginController : ApiController
    {
        // GET api/login
        public bool Get()
        {
            return false; //BLMemberInfo.Instance.CheckUserAvailability("rzee.m7@gmail.com"); // return null;//BLMemberInfo.Instance.CheckLogin(new UserInfo { UserName = "rzee.m7@gmail.com", Password = "admin" });
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        public Response Post([FromBody]UserInfo _userInfo)
        {
            return BLMemberInfo.Instance.CheckLogin(_userInfo);
        }

        // PUT api/login/5
        public bool Put(int id, [FromBody]string _userName)
        {
            return BLMemberInfo.Instance.CheckUserAvailability(_userName);
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }
    }
}
