using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLayer.ViewModels.Commands
{
    public class BorrowCommand : CommandBase
    {
        private readonly BorrowViewModel _brorrowViewModel;
        private readonly Library _library;
        private readonly NavigationService _homeViewNavigationService;

        public BorrowCommand(BorrowViewModel borrowViewModel, Library library, NavigationService homeViewNavigationService)
        {
            _brorrowViewModel = borrowViewModel;
            _library = library;
            _homeViewNavigationService = homeViewNavigationService;
            _brorrowViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BorrowViewModel.Isbn))
            {
                OnCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(BorrowViewModel.Email))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_brorrowViewModel.Isbn) && !string.IsNullOrEmpty(_brorrowViewModel.Email) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (int.TryParse(_brorrowViewModel.Isbn, out int isbn) && _library.NewBorrowEvent(isbn, _brorrowViewModel.Email) && !CommandBase.test_mod)
            {
                MessageBox.Show("Book borrowed.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _homeViewNavigationService.Navigate();
            }
            else if (!CommandBase.test_mod)
            {
                MessageBox.Show("Cannot borrow this book", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
