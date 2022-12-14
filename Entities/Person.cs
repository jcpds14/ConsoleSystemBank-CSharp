using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Contracts;

namespace DotNet.Entities
{
    public class Person
    {
        public int Id { get; set; }
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