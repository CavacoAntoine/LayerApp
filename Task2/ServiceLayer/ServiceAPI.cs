using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public abstract class ServiceAbstractAPI
    {
        protected DataAbstractAPI _dataAPI;

        public abstract bool IsBookExist(int isbn);
        public abstract IDictionary<string, string> GetBookByIsbn(int isbn);
        public abstract bool AddBook(int isbn, string author, string title);
        public abstract IDictionary<int, IDictionary<string, object>> GetStock();

        public abstract IDictionary<string, IDictionary<string, string>> GetCustomers();
        public abstract bool AddCustomer(string name, string surname, string email);

        public abstract bool BorrowBook(int isbn, string email);
        public abstract bool ReturnBook(int isbn, string email);

        public abstract int CountAvailableBook(int isbn);
        public abstract int CountBook(int isbn);



        public static ServiceAbstractAPI CreateService()
        {
            return new ServiceAPI();
        }

        private class ServiceAPI : ServiceAbstractAPI
        {

            public ServiceAPI()
            {
                _dataAPI = DataAbstractAPI.CreateDataAPI();
            }

            public override bool IsBookExist(int isbn)
            {
                return _dataAPI.IsCatalogExist(isbn);
            }
            public override IDictionary<string, string> GetBookByIsbn(int isbn)
            {
                return _dataAPI.GetCatalogsByIsbn(isbn);
            }
            public override bool AddBook(int isbn, string author, string title)
            {
                if (IsBookExist(isbn))
                {
                    return _dataAPI.AddState(isbn, '1');
                }
                else
                {
                    if (!_dataAPI.AddCatalog(isbn, author, title)) return false;
                    return _dataAPI.AddState(isbn, '1');
                }
            }
            public override IDictionary<int, IDictionary<string, object>> GetStock()
            {
                IDictionary<int, IDictionary<string, object>> states = _dataAPI.GetStates();

                IDictionary<int, IDictionary<string, object>> result = new Dictionary<int, IDictionary<string, object>>();


                foreach (IDictionary<string, object> state in states.Values)
                {
                    if (result.ContainsKey((int)state["isbn"]))
                    {
                        if ((char)state["availibility"] == '1')
                        {
                            object available = result[(int)state["isbn"]]["available"];
                            available = (int)available + 1;
                            result[(int)state["isbn"]]["available"] = available;
                        }

                        object quantity = result[(int)state["isbn"]]["quantity"];
                        quantity = (int)quantity + 1;
                        result[(int)state["isbn"]]["quantity"] = quantity;
                    }
                    else
                    {
                        IDictionary<string, string> catalog = _dataAPI.GetCatalogsByIsbn((int)state["isbn"]);
                        IDictionary<string, object> args = new Dictionary<string, object>();
                        args.Add("title", catalog["title"]);
                        args.Add("author", catalog["author"]);
                        if ((char)state["availibility"] == '1')
                        {
                            args.Add("available", 1);
                        }
                        else
                        {
                            args.Add("available", 0);
                        }
                        args.Add("quantity", 1);
                        result.Add((int)state["isbn"], args);
                    }
                }
                return result;
            }

            public override IDictionary<string, IDictionary<string, string>> GetCustomers()
            {
                return _dataAPI.GetUsers();
            }
            public override bool AddCustomer(string name, string surname, string email)
            {
                if (_dataAPI.IsUserExist(email)) return false;

                return _dataAPI.AddUser(name, surname, email);
            }

            public override bool BorrowBook(int isbn, string email)
            {
                if (_dataAPI.IsStateExist(isbn, '1') && _dataAPI.IsUserExist(email))
                {
                    int state_id = _dataAPI.GetStatesByIsbnAndAvailibility(isbn, '1').First();
                    return _dataAPI.AddActionBorrow(email, state_id);
                }
                return false;
            }
            public override bool ReturnBook(int isbn, string email)
            {
                if (!_dataAPI.IsUserExist(email)) return false;

                IDictionary<int, IDictionary<string, object>> actions = _dataAPI.GetActionsForUser(email, "Borrow");

                int state_id = -1;

                foreach (IDictionary<string, object> action in actions.Values)
                {
                    if (isbn == _dataAPI.GetIsbnOfStateByID((int)action["state_id"]))
                    {
                        state_id = (int)action["state_id"];
                        break;
                    }
                }

                if (_dataAPI.IsActionExist("Borrow", email, state_id))
                {
                    return _dataAPI.AddActionReturn(email, state_id);
                }
                return false;
            }

            public override int CountAvailableBook(int isbn)
            {
                return _dataAPI.GetStatesByIsbnAndAvailibility(isbn, '1').Count;
            }

            public override int CountBook(int isbn)
            {
                return _dataAPI.GetStatesByIsbn(isbn).Count;
            }
        }
    }
}
