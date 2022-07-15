using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User(string name, string surname, string email)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                this.Name == user.Name &&
                this.Surname == user.Surname &&
                this.Email == user.Email;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Email}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
