using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Model
{
    public class Catalog
    {
        public int Isbn { get; }
        public string Author { get; }
        public string Title { get; }
        public int Available { get; set; }
        public int Quantity { get; set; }


        public Catalog(int isbn, string author, string title, int available, int quantity)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Title = title;
            this.Available = available;
            this.Quantity = quantity;
        }
    }
}
