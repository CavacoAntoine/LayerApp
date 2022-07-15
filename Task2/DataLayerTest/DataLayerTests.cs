using DataLayer;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataLayerTest
{
    [TestClass]
    public class DataLayerTests
    {
        private DataAbstractAPI api;

        public DataAbstractAPI Api { get => api; set => api = value; }

        [TestInitialize]
        public void Initalise()
        {
            Api = DataAbstractAPI.CreateDataAPI();
        }

        [TestMethod]
        public void TestUser()
        {
            if (Api.IsUserExist("email@email.com"))
            {
                Assert.IsTrue(!Api.AddUser("Cavaco", "Antoine", "email@email.com"));
            }else
            {
                Assert.IsTrue(Api.AddUser("Cavaco", "Antoine", "email@email.com"));
            }

            Assert.IsTrue(Api.IsUserExist("email@email.com"));

        }

        [TestMethod]
        public void TestCatalog()
        {
            if (Api.IsCatalogExist(123456))
            {
                Assert.IsTrue(!Api.AddCatalog(123456, "Author", "Title"));
            }
            else
            {
                Assert.IsTrue(Api.AddCatalog(123456, "Author", "Title"));
            }

            Assert.IsTrue(Api.IsCatalogExist(123456));
        }

        [TestMethod]
        public void TestStates()
        {
            if (!Api.IsCatalogExist(123456))
            {
                Api.AddCatalog(123456, "Author", "Title");
            }

            Assert.IsTrue(Api.AddState(123456, '1'));
            Assert.IsTrue(Api.AddState(123456, '0'));

            Assert.IsTrue(Api.IsStateExist(123456, '1'));
            Assert.IsTrue(Api.IsStateExist(123456, '0'));
        }

        [TestMethod]
        public void TestActions()
        {
            if (!Api.IsUserExist("email@email.com"))
            {
                Api.AddUser("Cavaco", "Antoine", "email@email.com");
            }

            if (!Api.IsCatalogExist(123456))
            {
                Api.AddCatalog(123456, "Author", "Title");
            }

            if(!Api.IsStateExist(123456, '0'))
            {
                Api.AddState(123456, '0');
            }

            if (!Api.IsStateExist(123456, '1'))
            {
                Api.AddState(123456, '1');
            }

            List<int> states_available_id = Api.GetStatesByIsbnAndAvailibility(123456, '1');
            List<int> states_unavailable_id = Api.GetStatesByIsbnAndAvailibility(123456, '0');

            Assert.IsTrue(Api.AddActionBorrow("email@email.com", states_available_id.First()));
            Assert.IsTrue(Api.IsActionExist("Borrow", "email@email.com", states_available_id.First()));

            Assert.IsTrue(Api.AddActionReturn("email@email.com", states_unavailable_id.First()));
            Assert.IsTrue(Api.IsActionExist("Return", "email@email.com", states_unavailable_id.First()));

        }

    }
}
