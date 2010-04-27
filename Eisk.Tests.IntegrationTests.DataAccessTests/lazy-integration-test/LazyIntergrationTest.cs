using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eisk.TestHelpers;

namespace Eisk.Tests.IntegrationTests.LazyIntergrationTest
{
    /// <summary>
    /// Well you may not always like to do the repetitive tasks to write unit test for all of your data access layer components, especially for the generated codes. However if we could do it with a very minimal effort then that could be really great to gain our confidence with respect to our data access layer. We can easily do it by implementing a simple test class that implements exclusive use of .NET Reflection. You can get the full idea how to do it by checking the LazyUnitTestBase class.
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// Last update: 20-apr-2009
    /// </summary>
    public abstract class LazyIntergrationTestBase : DataAccessLayerBaseTest
    {
        LazyIntergrationTestBase() { }

        Type entity;

        protected LazyIntergrationTestBase(Type _entity)
        {
            entity = _entity;
        }

        [TestMethod()]
        public void CreateNewEntity_ValidNewEntityObjectPassed_ShouldReturnNonzero()
        {
            int newEntityId = (int)ReflectorHelper.StaticCallMethod(entity, "CreateNew" + entity.Name, EntityFactory.Factory_CreateFreshEntityWithValidSampleData(entity.Name));
            const int INITIAL_NO_ENTITY_STATE = 0;
            Assert.AreNotEqual(INITIAL_NO_ENTITY_STATE, newEntityId, entity.Name + " was not created.");
            Console.WriteLine("NEW " + entity.Name + " ID: " + newEntityId);
        }
    }

    [TestClass]
    public class EmployeeLazyIntergrationTest:LazyIntergrationTestBase
    {
        public EmployeeLazyIntergrationTest():base(typeof(Eisk.DataAccess.Employee))
        {
        }
    }
}
