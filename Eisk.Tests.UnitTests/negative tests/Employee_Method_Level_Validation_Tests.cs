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
    public class Employee_Method_Level_Validation_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Passing null 'Employee' parameter is invalid. Method should throw exception.")]
        public void CreateNewEmployee_NullEmployeeToBePassedAsArgument_ShouldThrowException()
        {
            Employee.CreateNewEmployee(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Non-zero EmployeeId while creating new employee is invalid.")]
        public void CreateNewEmployee_NonZeroEmployeeIdToBePassedAsArgument_ShouldThrowException()
        {
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            const int NON_ZERO_EMPLOYEE_ID = 1;
            freshEmployeeObjectWithValidSampleData.EmployeeId = NON_ZERO_EMPLOYEE_ID;
            Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
        }

    }
}

