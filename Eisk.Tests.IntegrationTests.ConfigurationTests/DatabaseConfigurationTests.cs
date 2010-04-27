﻿using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;
using Eisk.DataAccessHelpers;

namespace Eisk.Tests.IntegrationTests.ConfigurationTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    [TestClass]
    public class DatabaseConfigurationTests
    {
        public DatabaseConfigurationTests()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) 
        {
        }
        #endregion

        [TestMethod]
        public void ConnectionTest_OpensAConnection_ShouldPassIfSuccessful()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString))
                {
                    sqlCon.Open();
                }
            }
            catch (Exception e) 
            {
                Assert.Fail("Connection test is failed with the message: " + e.Message);
                throw;
            }
        }

        [TestMethod]
        public void SchemaGenerationTest_RunsSchemaGenerationScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CreateSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Generation is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void DataGenerationTest_RunsDataGenerationScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.GenerateTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Generation is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void DataCleanupTest_RunsDataCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void SchemaCleanupTest_RunsSchemaCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

    }
}
