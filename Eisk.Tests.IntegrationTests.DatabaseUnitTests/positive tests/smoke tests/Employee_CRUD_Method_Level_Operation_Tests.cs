using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Data.Schema.UnitTesting;
using Microsoft.Data.Schema.UnitTesting.Conditions;

namespace Eisk.Tests.IntegrationTests.DatabaseUnitTests
{
    [TestClass()]
    public class Eisk : DatabaseTestClass
    {

        public Eisk()
        {
            InitializeComponent();
        }

        //TransactionScope _ts;
        [TestInitialize()]
        public void TestInitialize()
        {
            //_ts = new TransactionScope();
            TestHelpers.TransactionHelper.TransactionStart();
            TestHelpers.TestDataHelper.CleanTestData();
            TestHelpers.TestDataHelper.GenerateTestData();

            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
            TestHelpers.TransactionHelper.TransactionLeave();
            // _ts.Dispose();
        }

        [TestMethod()]
        public void CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero()
        {
            DatabaseTestActions testActions = this.CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            ExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            ExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            ExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }
        [TestMethod()]
        public void GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords()
        {
            DatabaseTestActions testActions = this.GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            ExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            ExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            ExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }


        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eisk));
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction;
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction;
            Microsoft.Data.Schema.UnitTesting.DatabaseTestAction GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords_TestAction;
            this.CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData = new Microsoft.Data.Schema.UnitTesting.DatabaseTestActions();
            this.GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData = new Microsoft.Data.Schema.UnitTesting.DatabaseTestActions();
            CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords_TestAction = new Microsoft.Data.Schema.UnitTesting.DatabaseTestAction();
            // 
            // CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction
            // 
            resources.ApplyResources(CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction, "CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction");
            // 
            // CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction
            // 
            resources.ApplyResources(CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction, "CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction");
            // 
            // CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction
            // 
            resources.ApplyResources(CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction, "CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction");
            // 
            // GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords_TestAction
            // 
            resources.ApplyResources(GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords_TestAction, "GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeR" +
                    "ecords_TestAction");
            // 
            // CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData
            // 
            this.CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData.PosttestAction = CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PosttestAction;
            this.CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData.PretestAction = CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_PretestAction;
            this.CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData.TestAction = CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzero_TestAction;
            // 
            // GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData
            // 
            this.GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData.PosttestAction = null;
            this.GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData.PretestAction = null;
            this.GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData.TestAction = GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecords_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        private DatabaseTestActions CreateNewEmployee_ValidNewEmployeeDataPassed_ShouldReturnNonzeroData;
        private DatabaseTestActions GetAllEmployeesPagedCount_StoredProcedureCalled_ShouldReturnTotalCountOfEmployeeRecordsData;
    }
}
