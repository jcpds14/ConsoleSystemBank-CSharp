using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Models;

namespace DotNet.Contracts
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