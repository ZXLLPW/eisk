using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.TestHelpers
{
   /// <summary>
   /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
   /// </summary>
    public abstract class DataAccessLayerBaseTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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

        //You can use the following additional attributes as you write your tests:

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            //TransactionHelper.TransactionStart();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            //TransactionHelper.TransactionLeave();
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TransactionHelper.TransactionStart();
            TestHelpers.TestDataHelper.CleanTestData();
            TestHelpers.TestDataHelper.GenerateTestData();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            TransactionHelper.TransactionLeave();
        }

    }
}

