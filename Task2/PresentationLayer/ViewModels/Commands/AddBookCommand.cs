using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace PresentationLayer.ViewModels.Commands
{
    public class AddBookCommand : CommandBase
    {
        private readonly AddBookViewModel _addBookViewModel;
        private readonly Library _library;
        private readonly NavigationService _stockViewNavigationService;

        public AddBookCommand(AddBookViewModel addBookViewModel, Library library, NavigationService homeViewNavigationService)
        {
            _addBookViewModel = addBookViewModel;
            _library = library;
            _stockViewNavigationService = homeViewNavigationService;
            _addBookViewModel.PropertyChanged += OnViewModelPropertyChanged; ;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBookViewModel.ISBN))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(AddBookViewModel.Title))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(AddBookViewModel.Author))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(AddBookViewModel.Quantity))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addBookViewModel.ISBN) && !string.IsNullOrEmpty(_addBookViewModel.Title) && !string.IsNullOrEmpty(_addBookViewModel.Author) && !string.IsNullOrEmpty(_addBookViewModel.Quantity) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (int.TryParse(_addBookViewModel.Quantity, out int quantity))
            {
                for (int i = 0; i < quantity; i++)
                {
                    Catalog book = new Catalog(
                        int.Parse(_addBookViewModel.ISBN),
                        _addBookViewModel.Author,
                        _addBookViewModel.Title,
                        1,
                        1
                    );
                    if (!_library.AddBook(book) && !CommandBase.test_mod)
                    {
                        MessageBox.Show("Can't add to the database", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if(!CommandBase.test_mod)
                {
                    MessageBox.Show("Sucessfully added.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                    _stockViewNavigationService.Navigate();
                }
                
            }
            else if(!CommandBase.test_mod)
            {
                MessageBox.Show("Quantity is not a number", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
