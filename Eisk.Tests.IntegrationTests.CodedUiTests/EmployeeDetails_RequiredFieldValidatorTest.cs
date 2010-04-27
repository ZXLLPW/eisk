using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Eisk.TestHelpers;


namespace Eisk.Tests.IntegrationTests.CodedUiTests
{
    [CodedUITest]
    public class EmployeeDetails_RequiredFieldValidatorTest:CodedUiTestBase
    {
        public EmployeeDetails_RequiredFieldValidatorTest()
        {
        }

        [TestMethod]
        [DeploymentItem("..\\Eisk.Tests.IntegrationTests.CodedUiTests\\App_Data\\Links.xml")]
        [DataSource("MyXmlDataSource")]
        public void RequiredFieldValidatorTest_NoDataProvidedForRequiredFields_ShouldFireClientSideRequiredMessage()
        {
            //Data setup for url
            this.UIMap.Action_GoToEmployeeListingPageParams.UIBlankPageWindowsInteWindowUrl = testContextInstance.DataRow["EmployeeListingPage"].ToString();

            //Actions

            this.UIMap.Action_OpenBrowser();
            this.UIMap.Action_GoToEmployeeListingPage();
            this.UIMap.Action_ClickAddEmployeeButton();
            this.UIMap.Action_RemoveTheRequiredDataFieldsFromEmployeeDetails();
            this.UIMap.Action_ClickSaveMethodOnEmployeeDetails();

            //Assertions
            this.UIMap.Assert_ShouldShowFirstNameAsRequiredForEmptyFirstNameValue();

            //Actions
            this.UIMap.Action_CloseBrowserWindow();
        }

    }
}
