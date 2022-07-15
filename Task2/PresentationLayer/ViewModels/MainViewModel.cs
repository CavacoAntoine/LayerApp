using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly Library _library;

        public MainViewModel()
        {
            _navigationStore = new NavigationStore();
            _library = new Library();

            _navigationStore.CurrentViewModel = CreateHomeViewModel();

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel(new NavigationService(_navigationStore, CreateStockViewModel), new NavigationService(_navigationStore, CreateAddBookViewModel), new NavigationService(_navigationStore, CreateBorrowViewModel), new NavigationService(_navigationStore, CreateCustomersViewModel), new NavigationService(_navigationStore, CreateAddCustomerViewModel), new NavigationService(_navigationStore, CreateReturnViewModel));
        }
        private AddBookViewModel CreateAddBookViewModel()
        {
            return new AddBookViewModel(_library, new NavigationService(_navigationStore, CreateHomeViewModel));
        }
        private StockListViewModel CreateStockViewModel()
        {
            return new StockListViewModel(_library, new NavigationService(_navigationStore, CreateAddBookViewModel), new NavigationService(_navigationStore, CreateHomeViewModel));
        }
        private CustomersViewModel CreateCustomersViewModel()
        {
            return new CustomersViewModel(_library, new NavigationService(_navigationStore, CreateAddCustomerViewModel), new NavigationService(_navigationStore, CreateHomeViewModel));
        }

        private AddCustomerViewModel CreateAddCustomerViewModel()
        {
            return new AddCustomerViewModel(_library, new NavigationService(_navigationStore, CreateHomeViewModel));
        }

        private BorrowViewModel CreateBorrowViewModel()
        {
            return new BorrowViewModel(_library, new NavigationService(_navigationStore, CreateHomeViewModel));
        }

        private ReturnViewModel CreateReturnViewModel()
        {
            return new ReturnViewModel(_library, new NavigationService(_navigationStore, CreateHomeViewModel));
        }
    }
}
