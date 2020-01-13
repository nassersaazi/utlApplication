using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.ControlObjects
{
    public class Account
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public string MakeCreditDecision(int creditScore)
        {
            if (creditScore < 550)
                return "Declined";
            else if (creditScore <= 675)
                return "Maybe";
            else
                return "We look forward to doing business with you!";
        }

        public decimal Balance
        {
            get { return balance; }
        }
    };
}