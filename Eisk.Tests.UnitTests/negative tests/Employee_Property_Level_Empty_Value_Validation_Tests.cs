using System;
using Eisk.DataAccess;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.Tests.UnitTests.NegativeTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    [TestClass]
    public class Employee_Property_Level_Empty_Value_Validation_Tests
    {
        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Method should throw exception.")]
        //public void EmployeeId_DefaultEmployeeIdToBeAssigned_ShouldThrowException()
        //{
        //    Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
        //    employee.EmployeeId = Employee.EmployeeIdMinValue;
        //}
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'LastName' is invalid. Method should throw exception.")]
        public void LastName_EmptyLastNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.LastName = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'FirstName' is invalid. Method should throw exception.")]
        public void FirstName_EmptyFirstNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.FirstName = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Title' is invalid. Method should throw exception.")]
        public void Title_EmptyTitleToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Title = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'TitleOfCourtesy' is invalid. Method should throw exception.")]
        public void TitleOfCourtesy_EmptyTitleOfCourtesyToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.TitleOfCourtesy = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method should throw exception.")]
        public void BirthDate_EmptyBirthDateToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.BirthDate = DateTime.MinValue;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Method should throw exception.")]
        public void HireDate_EmptyHireDateToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.HireDate = DateTime.MinValue;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Address' is invalid. Method should throw exception.")]
        public void Address_EmptyAddressToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Address = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'City' is invalid. Method should throw exception.")]
        public void City_EmptyCityToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.City = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Region' is invalid. Method should throw exception.")]
        public void Region_EmptyRegionToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Region = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'PostalCode' is invalid. Method should throw exception.")]
        public void PostalCode_EmptyPostalCodeToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.PostalCode = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Country' is invalid. Method should throw exception.")]
        public void Country_EmptyCountryToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Country = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'HomePhone' is invalid. Method should throw exception.")]
        public void HomePhone_EmptyHomePhoneToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.HomePhone = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Extension' is invalid. Method should throw exception.")]
        public void Extension_EmptyExtensionToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Extension = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Photo' is invalid. Method should throw exception.")]
        public void Photo_EmptyPhotoToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Photo = new byte[0];
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'Notes' is invalid. Method should throw exception.")]
        public void Notes_EmptyNotesToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Notes = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty 'ReportsTo' is invalid. Method should throw exception.")]
        public void ReportsTo_EmptyReportsToToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.ReportsTo = 0;
        }
    }
}
