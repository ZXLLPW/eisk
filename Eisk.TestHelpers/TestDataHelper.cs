using Eisk.DataAccessHelpers;
using System;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class TestDataHelper
    {
        TestDataHelper(){}

        static string srciptRoot = @"..\..\..\..\Eisk.Database\Basic Scripts\";

        public static void CreateDatabase()
        {
            SqlScriptUtility.CreateDatabase("test_EmployeeInfo_SK_4_0", "Data source=" + ".\\SQLEXPRESS" + ";Integrated Security=yes;");
        }

        public static void CleanDatabase()
        {
            throw new NotImplementedException();
        }

        public static void CreateSchema()
        {
            SqlScriptUtility.RunScript(srciptRoot + "Schema\\Create-Schema.sql");
        }

        public static void CleanSchema()
        {
            SqlScriptUtility.RunScript(srciptRoot + "Schema\\Clean-Schema.sql");
        }

        public static void GenerateTestData()
        {
            SqlScriptUtility.RunScript(srciptRoot + "Data\\Create-Data.sql");
        }

        public static void CleanTestData()
        {
            SqlScriptUtility.RunScript(srciptRoot + "Data\\Clean-Data.sql");
        }

    }

}