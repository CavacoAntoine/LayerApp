using PresentationLayer.ViewModels.Commands;
using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class StockListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<StateViewModel> _stock;
        private readonly Library _library;

        public IEnumerable<StateViewModel> Stock => _stock;
        public ICommand AddBookCommand { get; }
        public ICommand GoBackCommand { get; }

        public StockListViewModel(Library library, NavigationService addBookNavigationService, NavigationService GoBackNavigationService)
        {
            _library = library;

            AddBookCommand = new NavigateCommand(addBookNavigationService);
            GoBackCommand = new NavigateCommand(GoBackNavigationService);

            _stock = new ObservableCollection<StateViewModel>();

            UpdateStock();
        }

        private void UpdateStock()
        {
            _stock.Clear();
            foreach (Catalog book in _library.GetStock())
            {
                StateViewModel stateViewModel = new StateViewModel(book);
                _stock.Add(stateViewModel);
            }
        }
    }
}
