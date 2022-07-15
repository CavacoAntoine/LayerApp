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
    public class AddCustomerCommand : CommandBase
    {
        private readonly AddCustomerViewModel _addCustomerViewModel;
        private readonly Library _library;
        private readonly NavigationService _customersViewNavigationService;

        public AddCustomerCommand(AddCustomerViewModel addCustomerViewModel, Library library, NavigationService homeViewNavigationService)
        {
            _addCustomerViewModel = addCustomerViewModel;
            _library = library;
            _customersViewNavigationService = homeViewNavigationService;
            _addCustomerViewModel.PropertyChanged += OnViewModelPropertyChanged; ;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddCustomerViewModel.Email))
            {
                OnCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(AddCustomerViewModel.Name))
            {
                OnCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(AddCustomerViewModel.Surname))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addCustomerViewModel.Email) && !string.IsNullOrEmpty(_addCustomerViewModel.Name) && !string.IsNullOrEmpty(_addCustomerViewModel.Surname) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            User customer = new User(_addCustomerViewModel.Name, _addCustomerViewModel.Surname, _addCustomerViewModel.Email);
            if (_library.AddUser(customer) && !CommandBase.test_mod)
            {
                MessageBox.Show("Sucessfully added.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _customersViewNavigationService.Navigate();
            }
            else if (!CommandBase.test_mod)
            {
                MessageBox.Show("Can't add this user", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
