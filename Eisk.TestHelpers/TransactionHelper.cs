using System;
using System.EnterpriseServices;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// While doing test, you may want to generate the test schema and data prior to the test case execution, let the test cases modify as required by them and finally turn the database back as it was before the test. This is an excellent process to perform test operations on the live database without having any impact due to test executions. This can be possible with very tiny effort by using COM+ Transaction, which has been implementing in TestHelperRoot.TransactionHelper class.
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class TransactionHelper
    {
        TransactionHelper() { }

        public static void TransactionStart()
        {
            // Enter a new transaction without inheriting from ServicedComponent
            Console.WriteLine("Attempting to enter a transactional context...");
            ServiceConfig config = new ServiceConfig();
            config.Transaction = TransactionOption.RequiresNew;
            ServiceDomain.Enter(config);
            Console.WriteLine("Attempt suceeded!");

        }

        public static void TransactionLeave()
        {
            Console.WriteLine("Attempting to Leave transactional context...");
            if (ContextUtil.IsInTransaction)
            {
                // Abort the running transaction
                ContextUtil.SetAbort();
            }
            ServiceDomain.Leave();
            Console.WriteLine("Left context!");
        }
    }

}