using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public abstract class Account : Bank, IAccount
    {
        //Construtor
        public Account()
        {
            this.AgencyNumber = "0001";
            Account.AcconuntNunberSequencial++;//Não se usa o this pois é um construtor abstract
            this.Movements = new List<BankStatement>();
        }
        //Atributos
        public double Balance { get; protected set; }
        public string AgencyNumber { get; private set; }
        public string AccountNumber { get; protected set; }
        public static int AcconuntNunberSequencial { get; private set; }
        private List<BankStatement> Movements;

        public double BalanceInquiry()
        {
            return this.Balance;
        }

        public void Deposit(double value)
        {
            DateTime dateNow = DateTime.Now;
            this.Movements.Add(new BankStatement(dateNow, "Depósito", value));

            this.Balance += value;
        }

        public bool WithDraw(double value)
        {
            if (value > this.BalanceInquiry())
                return false;

            DateTime dateNow = DateTime.Now;
            this.Movements.Add(new BankStatement(dateNow, "Saque", value));

            this.Balance -= value;
            return true;

        }
        public string GetAccountNumber()
        {
            return this.AccountNumber;
        }

        public string GetAgencyNumber()
        {
            return this.AgencyNumber;
        }

        public string GetBankCode()
        {
            return this.BankCode;
        }

        List<BankStatement> IAccount.BankStatement()
        {
            return this.Movements;
        }
    }
}