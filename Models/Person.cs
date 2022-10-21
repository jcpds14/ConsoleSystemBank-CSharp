using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Contracts;

namespace DotNet.Models
{
    public class Person
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public IAccount Account { get; set; }

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetLogin(string login)
        {
            this.Login = login;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}