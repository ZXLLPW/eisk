using System;
using Eisk.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    [TestClass]
    public class Employee_DataFields_WithValidValue_OnInsertMethod_Tests : DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void LastName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_LAST_NAME = "Doe";

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.LastName = EXPECTED_LAST_NAME;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database to check if the value was inserted successfully
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_LAST_NAME = insertedEmployee.LastName;

            //perform final testing
            Assert.AreEqual(EXPECTED_LAST_NAME, ACTUAL_LAST_NAME, "value was NOT inserted successfully.");
        }

        [TestMethod()]
        public void FirstName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            
            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_FIRST_NAME = "John";
            
            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.FirstName = EXPECTED_FIRST_NAME;
            
            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
            
            //retriving the newly inserted employee from database to check if the value was inserted successfully
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_FIRST_NAME = insertedEmployee.FirstName;
            
            //perform final testing
            Assert.AreEqual(EXPECTED_FIRST_NAME, ACTUAL_FIRST_NAME, "value was NOT inserted successfully.");
        }

    }
}
