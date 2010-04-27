using Eisk.DataAccess;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.Tests.UnitTests.PositiveTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    [TestClass]
    public class Employee_Property_Level_Default_Value_Tests
    {
        [TestMethod]
        public void PhotoPath_EmptyPhotoPathToBeAssigned_ShouldGetDefaultValue()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.PhotoPath = string.Empty;
            const string EXPECTED_DEFAULT_VALUE = "c:\\photos\\";
            string ACTUAL_DEFAULT_VALUE = employee.PhotoPath;
            Assert.AreEqual(EXPECTED_DEFAULT_VALUE, ACTUAL_DEFAULT_VALUE, "Defaule value not found!");
        }

        [TestMethod]
        public void PhotoPath_NullPhotoPathToBeAssigned_ShouldGetDefaultValue()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            employee.PhotoPath = null;
            const string EXPECTED_DEFAULT_VALUE = "c:\\photos\\";
            string ACTUAL_DEFAULT_VALUE = employee.PhotoPath;
            Assert.AreEqual(EXPECTED_DEFAULT_VALUE, ACTUAL_DEFAULT_VALUE, "Defaule value not found!");
        }
    }
}
