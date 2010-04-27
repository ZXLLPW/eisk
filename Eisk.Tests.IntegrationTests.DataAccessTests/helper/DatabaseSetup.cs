using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.TestHelpers
{
    [TestClass()]
    public class DatabaseSetupForDataAccessTests
    {
        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            TestDataHelper.CreateDatabase();
            TestDataHelper.CreateSchema();
        }
    }
}
