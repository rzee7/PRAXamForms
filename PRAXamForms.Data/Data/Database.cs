using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace PRAXamForms.Data
{
    public abstract class Database
    {
        protected const int CommandTimeout = 180; //3 mins

        protected Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string _connectionString { get; protected set; }

        protected abstract IDbConnection CreateConnection(string connectionString);

        protected abstract IDbDataAdapter CreateAdapter(DbCommand dbCommand);

        protected DbCommand CreateCommand(string commandText)
        {
            var connection = (DbConnection)CreateConnection(_connectionString);
            if (connection != null)
            {
                var command = connection.CreateCommand();
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = CommandTimeout;
                return command;
            }
            return null;
        }

        protected DataSet ExecuteQuery(string commandText)
        {
            var command = CreateCommand(commandText);

            if (command != null)
                return ExecuteQuery(command);

            return null;
        }

        protected DataSet ExecuteQuery(DbCommand command)
        {
            DataSet dsResult;

            using (var connection = (DbConnection)CreateConnection(_connectionString))
            {
                dsResult = new DataSet();
                command.Connection = connection;
                IDataAdapter adapter = CreateAdapter(command);

                if (adapter != null)
                    adapter.Fill(dsResult);
                else
                    return null;
            }
            return dsResult;
        }

        protected void ExecuteNonQuery(string commandText)
        {
            DbCommand command = CreateCommand(commandText);
            if (command != null)
                ExecuteNonQuery(command);
        }

        protected int ExecuteNonQuery(DbCommand command)
        {
            using (var connection = (DbConnection)CreateConnection(_connectionString))
            {
                if (connection != null)
                {
                    command.Connection = connection;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    return command.ExecuteNonQuery();
                }
            }
            return -1;
        }

        protected object ExecuteScalar(string commandText)
        {
            var command = CreateCommand(commandText);
            return command != null ? ExecuteScalar(command) : null;
        }

        protected object ExecuteScalar(DbCommand command)
        {
            object result = null;

            using (var connection = (DbConnection)CreateConnection(_connectionString))
            {
                if (connection != null)
                {
                    command.Connection = connection;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    result = command.ExecuteScalar();
                }
            }
            return result;
        }
    }
}
