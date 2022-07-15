using PresentationLayer.ViewModels.Commands;
using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        private readonly Library _library;

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCustomerViewModel(Library library, NavigationService HomeViewNavigationService)
        {
            SubmitCommand = new AddCustomerCommand(this, library, HomeViewNavigationService);
            CancelCommand = new NavigateCommand(HomeViewNavigationService);

            _library = library;
        }
    }
}
