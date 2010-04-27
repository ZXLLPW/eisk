using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Eisk.DataAccessHelpers
{
    public sealed class SqlScriptUtility
    {
        public static bool CreateDatabase(string dbName, string connectionString)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "USE master CREATE DATABASE " + dbName;
                sqlCmd.CommandType = CommandType.Text;
                SqlClientUtility.ExecuteNonQueryCmd(sqlCmd, connectionString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void RunScript(string scriptPath)
        {
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandText = ReadDataFromFile(scriptPath);
            sqlCmd.CommandType = CommandType.Text;
            SqlClientUtility.ExecuteNonQueryCmd(sqlCmd);
        }

        public static string ReadDataFromFile(string filePath)
        {
            FileStream fStream;

            // Reading the file content.
            fStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream);
            string line = sReader.ReadToEnd();
            sReader.Close();

            return line;
        }
    }
}
