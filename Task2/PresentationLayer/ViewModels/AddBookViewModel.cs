using PresentationLayer.ViewModels.Commands;
using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private readonly Library _library;

        private string _isbn;
        public string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _quantity;

        public string Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddBookViewModel(Library library, NavigationService HomeViewNavigationService)
        {
            SubmitCommand = new AddBookCommand(this, library, HomeViewNavigationService);
            CancelCommand = new NavigateCommand(HomeViewNavigationService);

            PropertyChanged += OnViewModelPropertyChanged;
            _library = library;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ISBN) && int.TryParse(ISBN, out int isbn))
            {
                if (_library.CatalogExist(isbn))
                {
                    Catalog book = _library.GetBookByISBN(isbn);
                    Title = book.Title;
                    Author = book.Author;
                }
                else
                {
                    Title = null;
                    Author = null;
                }
            }

        }

    }
}
