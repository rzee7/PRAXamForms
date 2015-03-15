using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using PRAXamForms.Core;


namespace PRAXamForms.Data
{
    public sealed class SqlDatabase : Database
    {
        #region ConnectionString & Stuff
        
        private SqlConnection sqlConnection = null;
        public SqlDatabase(string connectionString)
            : base(connectionString)
        {
            InitializeDatabase(connectionString);
        }
        private void InitializeDatabase(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        protected override IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        protected override IDbDataAdapter CreateAdapter(DbCommand command)
        {
            SqlCommand sqlCommand = command as SqlCommand;
            if (sqlCommand != null)
            {
                return new SqlDataAdapter(sqlCommand);
            }
            return null;
        }

        #endregion

        #region CRUD Methods

        public Collection<MemberInfo> GetAccessInfo(int ID) // If ID < 0 "Select All Member" else Single Member
        {
            Collection<MemberInfo> memberInfoList = null;

            DbCommand sqlCommand = CreateCommand(SqlConstants.GetMemberInfo);
            if (sqlCommand != null)
            {
                using (DbConnection connection = (DbConnection)CreateConnection(_connectionString))
                {
                    if (connection != null)
                    {
                        sqlCommand.Connection = connection;

                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        sqlCommand.Parameters.Add(new SqlParameter("@ID",ID));
                        DbDataReader reader = sqlCommand.ExecuteReader();
                        if (reader != null)
                        {
                            if (reader.HasRows)
                            {
                                MemberInfo tempMemberInfo = null;
                                memberInfoList = new Collection<MemberInfo>();
                                while (reader.Read()) //Reading data from sql data reader
                                {
                                    tempMemberInfo = new MemberInfo();
                                    tempMemberInfo.ID = (int)reader["ID"];
                                    tempMemberInfo.FirstName = reader["FirstName"].ToString().Trim();
                                    tempMemberInfo.LastName = reader["LastName"].ToString().Trim();
                                    tempMemberInfo.Title = reader["Title"].ToString().Trim();
                                    tempMemberInfo.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                    tempMemberInfo.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                                    tempMemberInfo.ProfileImage = reader["ProfileImage"].ToString().Trim();
                                    tempMemberInfo.FacebookUrl = reader["FacebookUrl"].ToString().Trim();
                                    tempMemberInfo.LinkedInUrl = reader["LinkedInUrl"].ToString().Trim();
                                    tempMemberInfo.TwitterUrl = reader["TwitterUrl"].ToString().Trim();
                                    tempMemberInfo.Gender = Convert.ToChar(reader["Gender"]);
                                    memberInfoList.Add(tempMemberInfo);
                                }
                            }
                        }
                    }
                }
                return memberInfoList;
            }
            return null;
        }

        public int AddUpdateMemberInfo(MemberInfo memberInfo)
        {
            DbCommand sqlCommand = CreateCommand(SqlConstants.AddUpdateMemberInfo);
            int _newMemberID = 0;
            if (sqlCommand != null)
            {
                using (DbConnection connection = (DbConnection)CreateConnection(_connectionString))
                {
                    if (connection != null)
                    {
                        sqlCommand.Connection = connection;
                        try
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("@ID", memberInfo.ID));
                            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", memberInfo.FirstName.Trim()));
                            sqlCommand.Parameters.Add(new SqlParameter("@LastName", memberInfo.LastName.Trim()));
                            sqlCommand.Parameters.Add(new SqlParameter("@Title", memberInfo.Title.Trim()));
                            sqlCommand.Parameters.Add(new SqlParameter("@ProfileImage", memberInfo.ProfileImage.Trim()));
                            sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", memberInfo.DateOfBirth));
                            sqlCommand.Parameters.Add(new SqlParameter("@DateOfJoining", memberInfo.DateOfJoining));
                            sqlCommand.Parameters.Add(new SqlParameter("@Gender", memberInfo.Gender));
                            sqlCommand.Parameters.Add(new SqlParameter("@FacebookUrl", memberInfo.FacebookUrl));
                            sqlCommand.Parameters.Add(new SqlParameter("@LinkedInUrl", memberInfo.LinkedInUrl));
                            sqlCommand.Parameters.Add(new SqlParameter("@TwitterUrl", memberInfo.TwitterUrl));
                            sqlCommand.Parameters.Add(new SqlParameter("@NewMemberID", ParameterDirection.Output));
                            sqlCommand.Parameters["@NewMemberID"].Direction = ParameterDirection.Output;

                            if (connection.State != ConnectionState.Open)
                                connection.Open();

                            sqlCommand.ExecuteNonQuery();
                            _newMemberID = Convert.ToInt32(sqlCommand.Parameters["@NewMemberID"].Value); //return New added member ID
                        }
                        catch (Exception ex)
                        {
                            return -1;
                        }
                    }
                }
            }
            return _newMemberID;
        }

        #endregion
    }
}