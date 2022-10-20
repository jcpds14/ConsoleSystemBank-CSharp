using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class Person
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Password { get; private set; }
        public IAccount Account { get; set; }

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetCPF(string cpf)
        {
            this.CPF = cpf;
        }
        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}