using PRAXamForms.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAXamForms.Data.BLL
{
    public class BLMemberInfo
    {

        #region Private Declaration

        private SqlDatabase sqlDatabase = null;
        private Response responseData = null;

        #endregion

        #region Constructor Init

        public BLMemberInfo()
        {
            sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["PRAXamFormsConnectionString"].ConnectionString);
            responseData = new Response();
        }

        private static readonly BLMemberInfo _instance = new BLMemberInfo();

        public static BLMemberInfo Instance
        {
            get
            {
                return _instance ?? new BLMemberInfo();
            }
        }


        #endregion

        #region Get Members

        public Response GetMembers(int id)
        {
            try
            {
                responseData.Members = sqlDatabase.GetAccessInfo(id);
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Error = ex.Message;
                return responseData;
            }
        }

        #endregion

        #region Add Update Member

        public int AddUpdateMember(MemberInfo _memberInfo)
        {
            try
            {
                return sqlDatabase.AddUpdateMemberInfo(_memberInfo);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        #region Check Login

        public Response CheckLogin(UserInfo _userInfo)
        {
            try
            {
                var resData = new Response();
                var res = sqlDatabase.CheckLogin(_userInfo);
                resData.Members.Add(res);
                return resData;
            }
            catch (Exception ex)
            {
                return new Response { Error = ex.Message };
            }
        }

        #endregion

        #region Check Login

        public bool CheckUserAvailability(string _userName)
        {
            try
            {
                return sqlDatabase.CheckUserAvailability(_userName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Register Member

        public int RegisterUser(UserInfo _userInfo)
        {
            try
            {
                return sqlDatabase.RegisterUser(_userInfo);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion

        public void GetReg()
        {

        }
    }
}
