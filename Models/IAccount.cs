using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public interface IAccount
    {
        void Deposit(double value);
        bool WithDraw(double value);
        double BalanceInquiry();
        string GetBankCode();
        string GetAgencyNumber();
        string GetAccountNumber();
        List<BankStatement> BankStatement();
    }
}