using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class DataAbstractAPI
    {
        public LibraryDataContext library;

        public abstract bool IsActionExist(string description, string email, int state_id);
        public abstract bool IsUserExist(string email);
        public abstract bool IsCatalogExist(int isbn);
        public abstract bool IsStateExist(int isbn, char availability);

        public abstract IDictionary<int, IDictionary<string, object>> GetActionsForUser(string email, string description);
        public abstract IDictionary<string, IDictionary<string, string>> GetUsers();
        public abstract IDictionary<string, string> GetUsersByEmail(string email);
        public abstract IDictionary<int, IDictionary<string, string>> GetCatalogs();
        public abstract IDictionary<string, string> GetCatalogsByIsbn(int isbn);
        public abstract IDictionary<int, IDictionary<string, object>> GetStates();
        public abstract IDictionary<int, IDictionary<string, char>> GetStatesByIsbn(int isbn);
        public abstract int GetIsbnOfStateByID(int state_id);
        public abstract List<int> GetStatesByIsbnAndAvailibility(int isbn, char availability);

        public abstract bool AddActionBorrow(string email, int state_id);
        public abstract bool AddActionReturn(string email, int state_id);
        public abstract bool AddUser(string name, string surname, string email);
        public abstract bool AddCatalog(int isbn, string author, string title);
        public abstract bool AddState(int isbn, char availibility);

        public abstract bool UpdateState(int state_id, char new_availibility);

        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataAPI(new LibraryDataContext());
        }

        private class DataAPI : DataAbstractAPI
        {

            public DataAPI(LibraryDataContext dataContext)
            {
                library = dataContext;
            }

            public override bool IsActionExist(string description, string email, int state_id)
            {
                IEnumerable<action> actions =
                     from action in library.actions
                     where action.description == description && action.email == email && action.state_id == state_id
                     select action;

                if (actions.Count() > 0)
                {
                    return true;
                }

                return false;
            }

            public override bool IsUserExist(string email)
            {
                IEnumerable<user> users =
                     from user in library.users
                     where user.email == email
                     select user;

                if (users.Count() > 0)
                {
                    return true;
                }

                return false;
            }
            public override bool IsCatalogExist(int isbn)
            {
                IEnumerable<catalog> catalogs =
                     from catalog in library.catalogs
                     where catalog.isbn == isbn
                     select catalog;

                if (catalogs.Count() > 0)
                {
                    return true;
                }

                return false;
            }
            public override bool IsStateExist(int isbn, char availability)
            {
                IEnumerable<state> states =
                     from state in library.states
                     where state.catalog.isbn == isbn && state.available == availability
                     select state;

                if (states.Count() > 0)
                {
                    return true;
                }

                return false;
            }

            public override IDictionary<int, IDictionary<string, object>> GetActionsForUser(string email, string description)
            {
                IEnumerable<action> actions =
                     from action in library.actions
                     where action.email == email && action.description == description
                     select action;

                IDictionary<int, IDictionary<string, object>> result = new Dictionary<int, IDictionary<string, object>>();

                foreach (action a in actions)
                {
                    IDictionary<string, object> args = new Dictionary<string, object>();
                    args.Add("description", a.description);
                    args.Add("state_id", a.state_id);
                    args.Add("email", a.email);
                    result.Add(a.action_id, args);
                }

                return result;
            }
            public override IDictionary<string, IDictionary<string, string>> GetUsers()
            {
                IEnumerable<user> users =
                     from user in library.users
                     select user;

                IDictionary<string, IDictionary<string, string>> result = new Dictionary<string, IDictionary<string, string>>();

                foreach (user u in users)
                {
                    IDictionary<string, string> args = new Dictionary<string, string>();
                    args.Add("name", u.name);
                    args.Add("surname", u.surname);
                    result.Add(u.email, args);
                }

                return result;
            }
            public override IDictionary<string, string> GetUsersByEmail(string email)
            {
                IEnumerable<user> users =
                     from user in library.users
                     where user.email == email
                     select user;

                IDictionary<string, string> result = new Dictionary<string, string>();

                user u = users.First();

                result.Add("name", u.name);
                result.Add("surname", u.surname);

                return result;
            }
            public override IDictionary<int, IDictionary<string, string>> GetCatalogs()
            {
                IEnumerable<catalog> catalogs =
                     from catalog in library.catalogs
                     select catalog;

                IDictionary<int, IDictionary<string, string>> result = new Dictionary<int, IDictionary<string, string>>();

                foreach (catalog c in catalogs)
                {
                    IDictionary<string, string> args = new Dictionary<string, string>();
                    args.Add("author", c.author);
                    args.Add("title", c.title);
                    result.Add(c.isbn, args);
                }

                return result;
            }
            public override IDictionary<string, string> GetCatalogsByIsbn(int isbn)
            {
                IEnumerable<catalog> catalogs =
                     from catalog in library.catalogs
                     where catalog.isbn == isbn
                     select catalog;

                IDictionary<string, string> result = new Dictionary<string, string>();

                catalog c = catalogs.First();

                result.Add("author", c.author);
                result.Add("title", c.title);

                return result;
            }
            public override IDictionary<int, IDictionary<string, object>> GetStates()
            {
                IEnumerable<state> states =
                     from state in library.states
                     select state;

                IDictionary<int, IDictionary<string, object>> result = new Dictionary<int, IDictionary<string, object>>();

                foreach (state s in states)
                {
                    IDictionary<string, object> args = new Dictionary<string, object>();
                    args.Add("isbn", s.isbn);
                    args.Add("availibility", s.available);
                    result.Add(s.state_id, args);
                }

                return result;
            }
            public override IDictionary<int, IDictionary<string, char>> GetStatesByIsbn(int isbn)
            {
                IEnumerable<state> states =
                     from state in library.states
                     where state.catalog.isbn == isbn
                     select state;

                IDictionary<int, IDictionary<string, char>> result = new Dictionary<int, IDictionary<string, char>>();

                foreach (state s in states)
                {
                    IDictionary<string, char> args = new Dictionary<string, char>();
                    args.Add("availibility", s.available);
                    result.Add(s.state_id, args);
                }

                return result;
            }
            public override List<int> GetStatesByIsbnAndAvailibility(int isbn, char availability)
            {
                IEnumerable<state> states =
                     from state in library.states
                     where state.catalog.isbn == isbn && state.available == availability
                     select state;

                List<int> result = new List<int>();

                foreach (state s in states)
                {
                    result.Add(s.state_id);
                }

                return result;

            }
            public override int GetIsbnOfStateByID(int state_id)
            {
                IEnumerable<state> states =
                     from state in library.states
                     where state.state_id == state_id
                     select state;

                return states.First().isbn;
            }

            public override bool AddActionBorrow(string email, int state_id)
            {
                try
                {
                    action new_action = new action
                    {
                        description = "Borrow",
                        state_id = state_id,
                        email = email
                    };

                    UpdateState(state_id, '0');
                    library.actions.InsertOnSubmit(new_action);
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            public override bool AddActionReturn(string email, int state_id)
            {
                try
                {
                    action new_action = new action
                    {
                        description = "Return",
                        state_id = state_id,
                        email = email
                    };

                    UpdateState(state_id, '1');
                    library.actions.InsertOnSubmit(new_action);
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            public override bool AddUser(string name, string surname, string email)
            {
                try
                {
                    user new_user = new user
                    {
                        name = name,
                        surname = surname,
                        email = email
                    };

                    library.users.InsertOnSubmit(new_user);
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public override bool AddCatalog(int isbn, string author, string title)
            {
                try
                {
                    catalog new_catalog = new catalog
                    {
                        isbn = isbn,
                        author = author,
                        title = title
                    };

                    library.catalogs.InsertOnSubmit(new_catalog);
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public override bool AddState(int isbn, char availibility)
            {
                try
                {
                    state new_state = new state
                    {
                        isbn = isbn,
                        available = availibility
                    };

                    library.states.InsertOnSubmit(new_state);
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public override bool UpdateState(int state_id, char new_availibility)
            {
                try
                {
                    state state = library.states.First(s => s.state_id == state_id && s.available != new_availibility);
                    state.available = new_availibility;
                    library.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
