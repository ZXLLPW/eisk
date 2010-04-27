using Eisk.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Eisk.Tests.UnitTests.PositiveTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    [TestClass]
    public class Employee_Property_Level_GetSet_Tests
    {
        [TestMethod]
        public void FirstName_PropertySetsValidValue_GetsSameValue()
        {
            Employee employee = new Employee();
            const string EXPECTED_FIRST_NAME = "Ashraf";
            employee.FirstName = EXPECTED_FIRST_NAME;
            string ACTUAL_FIRST_NAME = employee.FirstName; 
            Assert.AreEqual(EXPECTED_FIRST_NAME, ACTUAL_FIRST_NAME, "First name has not been properly initialyzed via constructor.");
        }
    }
}
