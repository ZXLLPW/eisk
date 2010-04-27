using System;
using Eisk.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    /// <summary>
    /// Each test class in regression test are sanity test for each CRUD method.
    /// Considers the data fields of Employee data container, for which 'allow null' is set.
    /// </summary>
    [TestClass]
    public class Employee_DataFields_WithValidNullValue_OnInsertMethod_Tests: DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void Title_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_TITLE = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Title = EXPECTED_TITLE;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_TITLE = insertedEmployee.Title;

            //perform final testing
            Assert.AreEqual(EXPECTED_TITLE, ACTUAL_TITLE, "Title was not saved with null value.");
        }

        [TestMethod()]
        public void TitleOfCourtecy_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_TITLE_OF_COURTECY = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.TitleOfCourtesy = EXPECTED_TITLE_OF_COURTECY;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_TITLE_OF_COURTECY = insertedEmployee.TitleOfCourtesy;

            //perform final testing
            Assert.AreEqual(EXPECTED_TITLE_OF_COURTECY, ACTUAL_TITLE_OF_COURTECY, "Title of Courtecy was not saved with null value.");
        }

        [TestMethod()]
        public void BirthDate_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            DateTime? EXPECTED_BIRTH_DATE = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.BirthDate = EXPECTED_BIRTH_DATE;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            DateTime? ACTUAL_BIRTH_DATE = insertedEmployee.BirthDate;

            //perform final testing
            Assert.AreEqual(EXPECTED_BIRTH_DATE, ACTUAL_BIRTH_DATE, "BirthDate was not saved with null value.");
        }

        [TestMethod()]
        public void City_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_CITY = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.City = EXPECTED_CITY;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_CITY = insertedEmployee.City;

            //perform final testing
            Assert.AreEqual(EXPECTED_CITY, ACTUAL_CITY, "City was not saved with null value.");
        }

        [TestMethod()]
        public void Region_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_REGION = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Region = EXPECTED_REGION;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_REGION = insertedEmployee.Region;

            //perform final testing
            Assert.AreEqual(EXPECTED_REGION, ACTUAL_REGION, "Region was not saved with null value.");
        }

        [TestMethod()]
        public void PostalCode_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_POSTALCODE = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.PostalCode = EXPECTED_POSTALCODE;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_POSTALCODE = insertedEmployee.PostalCode;

            //perform final testing
            Assert.AreEqual(EXPECTED_POSTALCODE, ACTUAL_POSTALCODE, "PostalCode was not saved with null value.");
        }

        [TestMethod()]
        public void Extension_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_EXTENSION = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Extension = EXPECTED_EXTENSION;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_EXTENSION = insertedEmployee.Extension;

            //perform final testing
            Assert.AreEqual(EXPECTED_EXTENSION, ACTUAL_EXTENSION, "Extension was not saved with null value.");
        }

        [TestMethod()]
        public void Photo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const byte[] EXPECTED_PHOTO = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Photo = EXPECTED_PHOTO;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            byte[] ACTUAL_PHOTO = insertedEmployee.Photo;

            //perform final testing
            Assert.AreEqual(EXPECTED_PHOTO, ACTUAL_PHOTO, "Photo was not saved with null value.");
        }

        [TestMethod()]
        public void Notes_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string EXPECTED_NOTES = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Notes = EXPECTED_NOTES;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_NOTES = insertedEmployee.Notes;

            //perform final testing
            Assert.AreEqual(EXPECTED_NOTES, ACTUAL_NOTES, "Notes was not saved with null value.");
        }

        [TestMethod()]
        public void ReportsTo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            int? EXPECTED_REPORTSTO = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.ReportsTo = EXPECTED_REPORTSTO;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            int? ACTUAL_REPORTSTO = insertedEmployee.ReportsTo;

            //perform final testing
            Assert.AreEqual(EXPECTED_REPORTSTO, ACTUAL_REPORTSTO, "ReportsTo was not saved with null value.");
        }

        [TestMethod()]
        public void PhotoPath_NullValueToBeInsertedToDatabase_ShouldReturnDefaultValueFromDatabase()
        {
            const string EXPECTED_DEFAULT_VALUE = "c:\\photos\\";

            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.PhotoPath = EXPECTED_DEFAULT_VALUE;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            string ACTUAL_DEFAULT_VALUE = insertedEmployee.PhotoPath;
            Assert.AreEqual(EXPECTED_DEFAULT_VALUE, ACTUAL_DEFAULT_VALUE, "Defaule value not found!");
        }
    }
}
