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
    public class Employee_Property_Level_Null_Value_Validation_Tests
    {
        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Method should throw exception.")]
        //public void EmployeeId_DefaultEmployeeIdToBeAssigned_ShouldThrowException()
        //{
        //    Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
        //    employee.EmployeeId = Employee.EmployeeIdMinValue;
        //}
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'LastName' is invalid. Method should throw exception.")]
        public void LastName_NullLastNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.LastName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'FirstName' is invalid. Method should throw exception.")]
        public void FirstName_NullFirstNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.FirstName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'Address' is invalid. Method should throw exception.")]
        public void Address_NullAddressToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Address = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'Country' is invalid. Method should throw exception.")]
        public void Country_NullCountryToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.Country = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'HomePhone' is invalid. Method should throw exception.")]
        public void HomePhone_NullHomePhoneToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.HomePhone = null;
        }
    }
}
