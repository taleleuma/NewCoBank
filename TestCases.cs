using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NewCoBank.Interfaces;
using NewCoBank.Enums;
using NewCoBank.Accounts;

namespace NewCoBank
{
    class Program
    {
        static void Main()
        {
            //test data
            IAccount checkingAcct = new CheckingAccount() { AccountNumber = 111, Balance = 100.99m, OwnerName = "John Doe" };
            IAccount investmentAcctIndiv = new InvestmentAccount() { AccountNumber = 222, Balance = 100.99m, OwnerName = "John Doe", CustomerType= EnumCustomerType.Individual };
            IAccount investmentAcctCorp = new InvestmentAccount() { AccountNumber = 333, Balance = 100.99m, OwnerName = "General Corp", CustomerType = EnumCustomerType.Corporate };

            decimal amt = 20, beforeBalance = 100.99m;
            
            //Checking Account test cases
            Debug.Assert(checkingAcct.Deposit(amt) && checkingAcct.Balance == (beforeBalance + amt));  //$120.99
            Debug.Assert(checkingAcct.WithDraw(amt) && checkingAcct.Balance == beforeBalance);       //$100.99

            //Investment- Individual Account test cases
            Debug.Assert(investmentAcctIndiv.Deposit(amt) && investmentAcctIndiv.Balance == (beforeBalance + amt));  //$120.99
            Debug.Assert(investmentAcctIndiv.WithDraw(amt) && investmentAcctIndiv.Balance == beforeBalance);       //$100.99

            //verify Error case
            Debug.Assert(investmentAcctIndiv.WithDraw(500.01m) == false && investmentAcctIndiv.Balance == beforeBalance);     //$100.99. balance should remain same


            //Investment- Corporate Account test cases
            Debug.Assert(investmentAcctCorp.Deposit(amt) && investmentAcctCorp.Balance == (beforeBalance + amt));  //$120.99
            Debug.Assert(investmentAcctCorp.WithDraw(amt) && investmentAcctCorp.Balance == beforeBalance);       //$100.99

            //Transfer among accounts: various combinations- test cases
            Debug.Assert(checkingAcct.Transfer(amt, investmentAcctIndiv) && checkingAcct.Balance == (beforeBalance - amt) && investmentAcctIndiv.Balance == beforeBalance + amt );
            Debug.Assert(checkingAcct.Transfer(amt, investmentAcctCorp) && checkingAcct.Balance == (beforeBalance - amt*2) && investmentAcctCorp.Balance == beforeBalance + amt);
            Debug.Assert(investmentAcctIndiv.Transfer(amt, investmentAcctCorp) && investmentAcctIndiv.Balance == beforeBalance && investmentAcctCorp.Balance == (beforeBalance + amt*2));



        }
    }
}
