using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Eisk.DataAccess;
using Eisk.TestHelpers;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    [TestClass]
    public class Employee_Method_Level_Performance_Tests : DataAccessLayerBaseTest
    {
        [TestMethod]
        public void CreateNewEmployee_ValidNewEmployeeObjectPassed_ShouldBeExecutedInLessThan1Sec()
        {
            //expected loading time is 1 second
            TimeSpan _ExpectedLoadTime = TimeSpan.FromSeconds(1);
            
            Stopwatch stopwatch = new Stopwatch();
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeObjectWithValidSampleData();
            
            //string the stopwatch
            stopwatch.Start();

            //test method goes here
            Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //stopping the stowatch
            stopwatch.Stop();

            Console.WriteLine("Method executed in toal seconds : " + stopwatch.Elapsed.TotalSeconds);
            Assert.IsTrue(stopwatch.Elapsed < _ExpectedLoadTime,
                string.Format(System.Globalization.CultureInfo.CurrentCulture, 
                "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
                stopwatch.Elapsed.TotalSeconds, _ExpectedLoadTime.TotalSeconds));

        }
    }
}
