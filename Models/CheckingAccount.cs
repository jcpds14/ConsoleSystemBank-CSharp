using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            this.AccountNumber = "00" + Account.AcconuntNunberSequencial;
        }
    }
}