using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data.Metadata.Edm;

namespace Eisk.DataAccessHelpers
{
    public sealed class SqlClientUtility
    {
        public static void SetCommandType(DbCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            if (cmdText == null)
                throw (new ArgumentNullException("cmdText"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }

        public static void AddParameterToSqlCmd(SqlCommand sqlCmd, string parameterId, SqlDbType sqlType, int parameterSize, ParameterDirection parameterDirection, object parameterValue)
        {
            // Validate Parameter Properties
            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (parameterId == null)
                throw (new ArgumentNullException("parameterId"));
            if (parameterId.Length == 0)
                throw (new ArgumentOutOfRangeException("parameterId"));

            if (parameterValue == null)
                parameterValue = DBNull.Value;

            // Add Parameter
            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = parameterId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = parameterDirection;

            if (parameterSize > 0)
                newSqlParam.Size = parameterSize;

            if (parameterValue != null)
                newSqlParam.Value = parameterValue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        #region Core Execute Utility

        public static Object ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            return ExecuteScalarCmd(sqlCmd, ConnectionStringManager.DefaultDBConnectionString);
        }
        
        public static Object ExecuteScalarCmd(SqlCommand sqlCmd, string connectionString)
        {
            // Validate Command Properties
            if (connectionString == null)
                throw (new ArgumentNullException("connectionString"));

            if ( connectionString.Length == 0)
                throw (new ArgumentOutOfRangeException("connectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            Object result = null;

            //The using block causes to close the data connection properly after the command execution.

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    sqlCmd.Connection = cn;
                    cn.Open();
                    result = sqlCmd.ExecuteScalar();
                   
                }

            return result;
        }

        public static int ExecuteNonQueryCmd(SqlCommand sqlCmd)
        {

            return ExecuteNonQueryCmd(sqlCmd, ConnectionStringManager.DefaultDBConnectionString);
        }

        public static int ExecuteNonQueryCmd(SqlCommand sqlCmd, string connectionString)
        {
            // Validate Command Properties
            if (connectionString == null)
                throw (new ArgumentNullException("connectionString"));

            if (connectionString.Length == 0)
                throw (new ArgumentOutOfRangeException("connectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            int result;

            //The using block causes to close the data connection properly after the command execution.
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            return result;
        }

        public static IList ExecuteReaderCmd(SqlCommand sqlCmd, GenerateCollectionFromReader generateCollectionDelegateObject)
        {
            return ExecuteReaderCmd(sqlCmd, generateCollectionDelegateObject, ConnectionStringManager.DefaultDBConnectionString);
        }
        
        public static IList ExecuteReaderCmd(SqlCommand sqlCmd, GenerateCollectionFromReader generateCollectionDelegateObject, string connectionString)
        {
            if (connectionString == null)
                throw (new ArgumentNullException("connectionString"));

            if (connectionString.Length == 0)
                throw (new ArgumentOutOfRangeException("connectionString"));

            if ( generateCollectionDelegateObject == null)
                throw (new ArgumentNullException("generateCollectionDelegateObject"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                IList temp = generateCollectionDelegateObject(sqlCmd.ExecuteReader());
                return (temp);
            }
        }

        #endregion
    }
}
