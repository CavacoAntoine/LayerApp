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
    public class ReturnCommand : CommandBase
    {
        private readonly ReturnViewModel _returnViewModel;
        private readonly Library _library;
        private readonly NavigationService _homeViewNavigationService;

        public ReturnCommand(ReturnViewModel returnViewModel, Library library, NavigationService homeViewNavigationService)
        {
            _returnViewModel = returnViewModel;
            _library = library;
            _homeViewNavigationService = homeViewNavigationService;
            _returnViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ReturnViewModel.Isbn))
            {
                OnCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(ReturnViewModel.Email))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_returnViewModel.Isbn) && !string.IsNullOrEmpty(_returnViewModel.Email) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (int.TryParse(_returnViewModel.Isbn, out int isbn) && _library.NewReturnEvent(isbn, _returnViewModel.Email) && !CommandBase.test_mod)
            {
                MessageBox.Show("Book returned.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _homeViewNavigationService.Navigate();
            }
            else if (!CommandBase.test_mod)
            {
                MessageBox.Show("Cannot return this book", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
