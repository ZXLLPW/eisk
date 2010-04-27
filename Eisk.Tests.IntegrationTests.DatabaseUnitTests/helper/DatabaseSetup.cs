using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;
using Microsoft.Data.Schema.UnitTesting;

namespace Eisk.TestHelpers
{
    [TestClass()]
    public class DatabaseSetupForDatabaseUnitTests
    {
        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            TestDataHelper.CreateDatabase();
            TestDataHelper.CreateSchema();
        }
    }
}

