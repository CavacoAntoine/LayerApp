using PresentationLayer.ViewModels.Commands;
using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ObservableCollection<UserViewModel> _customers;
        private readonly Library _library;

        public IEnumerable<UserViewModel> Customers => _customers;
        public ICommand AddCustomerCommand { get; }
        public ICommand GoBackCommand { get; }

        public CustomersViewModel(Library library, NavigationService addCustomerNavigationService, NavigationService GoBackNavigationService)
        {
            _library = library;

            AddCustomerCommand = new NavigateCommand(addCustomerNavigationService);
            GoBackCommand = new NavigateCommand(GoBackNavigationService);

            _customers = new ObservableCollection<UserViewModel>();

            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            _customers.Clear();
            foreach (User customer in _library.GetCustomers())
            {
                UserViewModel userViewModel = new UserViewModel(customer);
                _customers.Add(userViewModel);
            }
        }
    }
}
