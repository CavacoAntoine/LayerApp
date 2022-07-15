using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{
    public class Library
    {
        private readonly ServiceAbstractAPI serviceAPI;
        private readonly IDictionary<int, Event> _events;
        private readonly IDictionary<int, Catalog> _stock;
        private readonly IDictionary<string, User> _customers;

        public Library() : this(ServiceAbstractAPI.CreateService())
        {
        }
        public Library(ServiceAbstractAPI serviceAbstractAPI)
        {
            serviceAPI = serviceAbstractAPI;
            _events = new Dictionary<int, Event>();
            _stock = new Dictionary<int, Catalog>();
            foreach (KeyValuePair<int, IDictionary<string, object>> catalogs in serviceAPI.GetStock())
            {
                Catalog catalog = new Catalog(catalogs.Key, (string)catalogs.Value["author"], (string)catalogs.Value["title"], (int)catalogs.Value["available"], (int)catalogs.Value["quantity"]);
                _stock.Add(catalogs.Key, catalog);
            }
            _customers = new Dictionary<string, User>();
            foreach (KeyValuePair<string, IDictionary<string, string>> customers in serviceAPI.GetCustomers())
            {
                User customer = new User((string)customers.Value["name"], (string)customers.Value["surname"], customers.Key);
                _customers.Add(customers.Key, customer);
            }
        }

        public Catalog GetBookByISBN(int isbn)
        {
            if (_stock.ContainsKey(isbn))
            {
                return _stock[isbn];
            }

            IDictionary<string, string> book = serviceAPI.GetBookByIsbn(isbn);
            Catalog catalog = new Catalog(isbn, book["author"], book["title"], serviceAPI.CountAvailableBook(isbn), serviceAPI.CountBook(isbn));
            _stock.Add(isbn, catalog);
            return catalog;
        }

        public IEnumerable<Catalog> GetStock()
        {
            return _stock.Values;
        }

        public IEnumerable<User> GetCustomers()
        {
            return _customers.Values;
        }

        public bool NewBorrowEvent(int isbn, string email)
        {
            if(serviceAPI.BorrowBook(isbn, email))
            {
                _stock[isbn].Available--;
                return true;
            }
            return false;
        }

        public bool NewReturnEvent(int isbn, string email)
        {
            if (serviceAPI.ReturnBook(isbn, email))
            {
                _stock[isbn].Available++;
                return true;
            }
            return false;
        }
        public bool AddBook(Catalog book)
        {
            if (!serviceAPI.AddBook(book.Isbn, book.Author, book.Title))
            {
                return false;
            }

            if (_stock.ContainsKey(book.Isbn))
            {
                _stock[book.Isbn].Quantity++;
                _stock[book.Isbn].Available++;
                
            }
            else
            {
                _stock.Add(book.Isbn, book);
            }

            return true;
        }

        public bool AddUser(User customer)
        {
            if (_customers.ContainsKey(customer.Email))
            {
                return false;
            }
            else
            {
                if (serviceAPI.AddCustomer(customer.Name, customer.Surname, customer.Email))
                {
                    _customers.Add(customer.Email, customer);
                    return true;
                }
                return false;
            }
        }

        public bool CatalogExist(int isbn)
        {
            return _stock.ContainsKey(isbn) || serviceAPI.IsBookExist(isbn);
        }
    }
}
