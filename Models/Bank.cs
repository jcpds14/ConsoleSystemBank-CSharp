using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public abstract class Bank
    {
        public Bank()
        {
            this.BankName = "JcBANK";
            this.BankCode = "013";
        }
        public string BankName { get; private set; }
        public string BankCode { get; private set; }
    }
}