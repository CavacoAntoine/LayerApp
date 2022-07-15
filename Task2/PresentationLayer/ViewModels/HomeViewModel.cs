using PresentationLayer.ViewModels.Commands;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand GoViewStock { get; }
        public ICommand GoAddBook { get; }
        public ICommand GoBorrowBook { get; }
        public ICommand GoViewCustomers { get; }
        public ICommand GoAddCustomer { get; }
        public ICommand GoReturnBook { get; }

        public HomeViewModel(NavigationService stockViewNavigationService,
                            NavigationService AddBookViewNavigationService,
                            NavigationService BorrowViewNavigationService,
                            NavigationService customersViewNavigationService,
                            NavigationService AddCustomerViewNavigationService,
                            NavigationService ReturnViewNavigationService)
        {
            GoViewStock = new NavigateCommand(stockViewNavigationService);
            GoAddBook = new NavigateCommand(AddBookViewNavigationService);
            GoBorrowBook = new NavigateCommand(BorrowViewNavigationService);
            GoViewCustomers = new NavigateCommand(customersViewNavigationService);
            GoAddCustomer = new NavigateCommand(AddCustomerViewNavigationService);
            GoReturnBook = new NavigateCommand(ReturnViewNavigationService);
        }

    }
}
