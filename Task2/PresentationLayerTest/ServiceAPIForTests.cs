using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerTest
{
    public class ServiceAPIForTests : ServiceAbstractAPI
    {
        public override bool AddBook(int isbn, string author, string title)
        {
            return true;
        }

        public override bool AddCustomer(string name, string surname, string email)
        {
            return true;
        }

        public override bool BorrowBook(int isbn, string email)
        {
            return true;
        }

        public override int CountAvailableBook(int isbn)
        {
            throw new NotImplementedException();
        }

        public override int CountBook(int isbn)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, string> GetBookByIsbn(int isbn)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, IDictionary<string, string>> GetCustomers()
        {
            return new Dictionary<string, IDictionary<string,string>>();
        }

        public override IDictionary<int, IDictionary<string, object>> GetStock()
        {
            return new Dictionary<int, IDictionary<string, object>>();
        }

        public override bool IsBookExist(int isbn)
        {
            return false;
        }

        public override bool ReturnBook(int isbn, string email)
        {
            return true;
        }
    }
}
