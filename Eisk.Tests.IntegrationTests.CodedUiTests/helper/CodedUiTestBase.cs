using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.Tests.IntegrationTests.CodedUiTests;

namespace Eisk.TestHelpers
{
   /// <summary>
   /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
   /// </summary>
    public abstract class CodedUiTestBase
    {
        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;

        protected TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //TransactionHelper.TransactionStart();
            TestHelpers.TestDataHelper.CleanTestData();
            TestHelpers.TestDataHelper.GenerateTestData();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //TransactionHelper.TransactionLeave();
        }

    }
}

