using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Model;
using PresentationLayer.ViewModels;
using PresentationLayer.ViewModels.NavigationServices;
using PresentationLayer.ViewModels.Commands;

namespace PresentationLayerTest
{
    [TestClass]
    public class ViewModelsTests
    {
        private Library library_1;
        private Library library_2;
        private NavigationService navigationService; 

        [TestInitialize]
        public void InitaliseData()
        {
            navigationService = new NavigationService(new NavigationStore(), CreateViewModelBase);
            CommandBase.test_mod = true;
            generateData1();
            generateDate2();
        }

        public void generateData1()
        {
            library_1 = new Library(new ServiceAPIForTests());
            Assert.IsTrue(library_1.AddBook(new Catalog(123456, "Author", "Title", 1, 1)));
            Assert.IsTrue(library_1.AddUser(new User("Cavaco", "Antoine", "email@email.com")));
        }

        public ViewModelBase CreateViewModelBase()
        {
            return new ViewModelBase();
        }

        public void generateDate2()
        {
            library_2 = new Library(new ServiceAPIForTests());
            Assert.IsTrue(library_2.AddBook(new Catalog(98765, "An Author", "A Title", 1, 1)));
            Assert.IsTrue(library_2.AddUser(new User("Name", "Surname", "namesurname@email.com")));
        }

        [TestMethod]
        public void TestAddBookViewModel()
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel(library_1, navigationService);
            addBookViewModel.ISBN = "1234567";
            addBookViewModel.Quantity = "1";
            addBookViewModel.Author = "Other author";
            addBookViewModel.Title = "Other title";

            Assert.IsTrue(addBookViewModel.SubmitCommand.CanExecute(new object()));
            addBookViewModel.SubmitCommand.Execute(new object());
            Assert.IsTrue(library_1.CatalogExist(1234567));
        }

        [TestMethod]
        public void TestAddCustomerViewModel()
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel(library_1, navigationService);
            addCustomerViewModel.Email = "test@test.com";
            addCustomerViewModel.Name = "Test1";
            addCustomerViewModel.Surname = "Test1";

            Assert.IsTrue(addCustomerViewModel.SubmitCommand.CanExecute(new object()));
            addCustomerViewModel.SubmitCommand.Execute(new object());
            bool result = false;
            foreach(User u in library_1.GetCustomers())
            {
                if(u.Email == "test@test.com")
                {
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestStockListViewModel()
        {
            StockListViewModel stockListViewModel = new StockListViewModel(library_1, navigationService, navigationService);
            Assert.IsTrue(stockListViewModel.Stock.Count() == 1);
            StateViewModel stateViewModel = stockListViewModel.Stock.First();

            Assert.IsTrue(stateViewModel.ISBN == "123456");
            Assert.IsTrue(stateViewModel.Author == "Author");
            Assert.IsTrue(stateViewModel.Title == "Title");

            stockListViewModel = new StockListViewModel(library_2, navigationService, navigationService);
            Assert.IsTrue(stockListViewModel.Stock.Count() == 1);
            stateViewModel = stockListViewModel.Stock.First();

            Assert.IsTrue(stateViewModel.ISBN == "98765");
            Assert.IsTrue(stateViewModel.Author == "An Author");
            Assert.IsTrue(stateViewModel.Title == "A Title");
        }

        [TestMethod]
        public void TestCustomersViewModel()
        {
            CustomersViewModel customersViewModel = new CustomersViewModel(library_1, navigationService, navigationService);
            Assert.IsTrue(customersViewModel.Customers.Count() == 1);
            UserViewModel userViewModel = customersViewModel.Customers.First();

            Assert.IsTrue(userViewModel.Name == "Cavaco");
            Assert.IsTrue(userViewModel.Surname == "Antoine");
            Assert.IsTrue(userViewModel.Email == "email@email.com");

            customersViewModel = new CustomersViewModel(library_2, navigationService, navigationService);
            Assert.IsTrue(customersViewModel.Customers.Count() == 1);
            userViewModel = customersViewModel.Customers.First();

            Assert.IsTrue(userViewModel.Name == "Name");
            Assert.IsTrue(userViewModel.Surname == "Surname");
            Assert.IsTrue(userViewModel.Email == "namesurname@email.com");
        }

    }
}
