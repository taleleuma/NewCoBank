using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCoBank.Base;

namespace NewCoBank.Accounts
{
    public class CheckingAccount : BaseAccount
    {
        public override bool IsValidWithdrawal(decimal amount)
        {
            //no validations for Checking account at this moment. can be added here, in future
            return true;
        }
    }
}
