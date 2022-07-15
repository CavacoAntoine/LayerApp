using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.ViewModels
{
    public class StateViewModel : ViewModelBase
    {
        private readonly Catalog _book;

        public string ISBN => _book.Isbn.ToString();
        public string Title => _book.Title;
        public string Author => _book.Author;
        public string Available => _book.Available.ToString();

        public string Quantity => _book.Quantity.ToString();

        public StateViewModel(Catalog book)
        {
            _book = book;
        }

    }
}
