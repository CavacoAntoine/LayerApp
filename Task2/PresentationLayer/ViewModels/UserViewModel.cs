using PresentationLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User user;

        public string Email => user.Email;
        public string Name => user.Name;
        public string Surname => user.Surname;

        public UserViewModel(User user)
        {
            this.user = user;
        }
    }
}
