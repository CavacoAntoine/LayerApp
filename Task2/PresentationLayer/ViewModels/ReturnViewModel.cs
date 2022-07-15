using PresentationLayer.ViewModels.Commands;
using PresentationLayer.Model;
using PresentationLayer.ViewModels.NavigationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class ReturnViewModel : ViewModelBase
    {
        private readonly Library _library;

        private string _isbn;
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
                OnPropertyChanged(nameof(Isbn));
            }
        }
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ReturnViewModel(Library library, NavigationService HomeViewNavigationService)
        {
            SubmitCommand = new ReturnCommand(this, library, HomeViewNavigationService);
            CancelCommand = new NavigateCommand(HomeViewNavigationService);

            _library = library;
        }
    }
}
