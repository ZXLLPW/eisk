using System;
using System.Data.SqlClient;
using Eisk.Helpers;

namespace Eisk.DataAccessHelpers
{
    public sealed class ConnectionStringManager
    {
        #region Connection String

        static string _defaultDBConnectionString = string.Empty;

        public static string DefaultDBConnectionString
        {
            get
            {
                _defaultDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Keys.ConstConnectionStringKey].ConnectionString;
                if (String.IsNullOrEmpty(_defaultDBConnectionString))
                    return String.Empty;
                else
                    return _defaultDBConnectionString;
            }
            //set { _defaultDBConnectionString = value; }
        }

        public static string DefaultDBConnectionString2
        {
            get
            {
                _defaultDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString;
                if (String.IsNullOrEmpty(_defaultDBConnectionString))
                    return String.Empty;
                else
                    return _defaultDBConnectionString;
            }
            //set { _defaultDBConnectionString = value; }
        }
        #endregion

        public static string GetConnectionString(string dataSource, string database, string userName, string password)
        {
            return "Data Source=" + dataSource + ";Initial Catalog=" + database +
                ";Persist Security Info=True;User ID=" + userName + "; Password=" + password + ";";

        }

        public static bool IsConnectionStringOk()
        {
            return IsConnectionStringOk(DefaultDBConnectionString);
        }

        public static bool IsConnectionStringOk(string connectionString)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}