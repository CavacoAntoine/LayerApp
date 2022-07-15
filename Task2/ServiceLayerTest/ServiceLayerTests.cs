using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayerTest
{
    [TestClass]
    public class ServiceLayerTests
    {
        [TestMethod]
        public void TestAddCustomer()
        {
            ServiceAbstractAPI service = ServiceAbstractAPI.CreateService();

            if (!service.AddCustomer("Cavaco", "Antoine", "email@email.com"))
            {
                Assert.IsTrue(!service.AddCustomer("Cavaco", "Antoine", "email@email.com"));

            }

            IDictionary<string, IDictionary<string, string>> customers = service.GetCustomers();
            
            Assert.IsTrue(customers["email@email.com"]["name"] == "Cavaco");
        }

        [TestMethod]
        public void TestAddBook()
        {
            ServiceAbstractAPI service = ServiceAbstractAPI.CreateService();

            IDictionary<int, IDictionary<string, object>> old_states = service.GetStock();

            int old_available, old_quantity;
            if (!old_states.ContainsKey(123456))
            {
                old_available = 0;
                old_quantity = 0;
            }
            else
            {
                old_available = (int)old_states[123456]["available"];
                old_quantity = (int)old_states[123456]["quantity"];
            }

            Assert.IsTrue(service.AddBook(123456, "Author", "Title"));
            Assert.IsTrue(service.AddBook(123456, "Author", "Title"));

            IDictionary<int, IDictionary<string, object>> states = service.GetStock();

            Assert.IsTrue((string)states[123456]["title"] == "Title");
            Assert.IsTrue((int)states[123456]["available"] == (old_available + 2));
            Assert.IsTrue((int)states[123456]["quantity"] == (old_quantity + 2));
        }


        [TestMethod]
        public void TestBorrowBook()
        {
            ServiceAbstractAPI service = ServiceAbstractAPI.CreateService();
            Assert.IsTrue(service.BorrowBook(123456, "email@email.com"));
        }

        [TestMethod]
        public void TestReturnBook()
        {
            ServiceAbstractAPI service = ServiceAbstractAPI.CreateService();
            Assert.IsTrue(service.ReturnBook(123456, "email@email.com"));
        }
    }
}
