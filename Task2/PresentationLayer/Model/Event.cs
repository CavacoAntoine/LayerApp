using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Model
{
    public abstract class Event
    {
        public string Desc { get; protected set; }
        public Catalog Catalog { get; }
        public User User { get; }

        public Event(Catalog catalog, User user)
        {
            this.Catalog = catalog;
            this.User = user;
        }
    }

    public class BorrowEvent : Event
    {
        public BorrowEvent(Catalog catalog, User user) : base(catalog, user)
        {
            this.Desc = "Borrow";
        }
    }

    public class ReturnEvent : Event
    {
        public ReturnEvent(Catalog catalog, User user) : base(catalog, user)
        {
            this.Desc = "Return";
        }
    }
}
