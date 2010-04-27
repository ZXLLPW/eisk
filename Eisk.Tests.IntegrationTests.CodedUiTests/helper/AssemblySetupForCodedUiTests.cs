using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.TestHelpers
{
    [TestClass()]
    public class AssemblySetupForCodedUiTests
    {
        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            WebServerHelper.StartWebServer();
            TestDataHelper.CreateDatabase();
            TestDataHelper.CreateSchema();
        }

        [AssemblyCleanup()]
        public static void CleanupAssembly()
        {
            //WebServerHelper.StopWebServer();
        }
    }
}
