using Eisk.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;
using System.Collections.Generic;
using System;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    [TestClass]
    public class Employee_CRUD_Method_Level_Operation_Tests : DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void CreateNewEmployee_ValidNewEmployeeObjectPassed_ShouldReturnNonzero()
        {
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            int NEW_EMPLOYEE_ID = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
            const int INITIAL_NO_EMPLOYEE_STATE = 0;
            Assert.AreNotEqual(INITIAL_NO_EMPLOYEE_STATE, NEW_EMPLOYEE_ID, "Employee was not created.");
        }

        [TestMethod()]
        public void GetAllEmployeesPagedCount_MethodCalled_ShouldReturnTotalCountOfEmployeeRecords()
        {
            int ACTUAL_COUNT = Employee.GetAllEmployeesPagedCount(string.Empty, 0, 0);
            const int EXPECTED_COUNT = 11;
            Assert.AreEqual(EXPECTED_COUNT, ACTUAL_COUNT, "Count doesn't match!");
        }
    }
}
