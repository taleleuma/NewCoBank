using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCoBank.Interfaces
{
    public interface IAccount
    {
        int AccountNumber { get; set; }
        string OwnerName { get; set; }
        decimal Balance { get; set; }

        bool Deposit(decimal amount);
        bool WithDraw(decimal amount);
        bool Transfer(decimal amount, IAccount destinationAccount);

        //add additional Account based properties/methods, here

    }
}
