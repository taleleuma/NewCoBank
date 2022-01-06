using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NewCoBank.Interfaces;

namespace NewCoBank.Base
{
    public abstract class BaseAccount : IAccount
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        public abstract bool IsValidWithdrawal(decimal amount);

        public bool Deposit(decimal amount)
        {
            this.Balance += amount;
            return true;
        }

        public bool WithDraw(decimal amount)
        {
            if (IsValidWithdrawal(amount))
            {
                this.Balance -= amount;
                return true;
            }
            else
                return false;
        }

        public bool Transfer(decimal amount, IAccount destinationAccount)
        {
                this.Balance -= amount;
                destinationAccount.Balance += amount;
                return true;
        }

        //Write any private methods belonging to an Account, here, in future

    }
}
