using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCoBank.Base;
using NewCoBank.Enums;

namespace NewCoBank.Accounts
{
    public class InvestmentAccount : BaseAccount 
    {
        public EnumCustomerType CustomerType { get; set; }  //e.g. Individual, Corporate

        public override bool IsValidWithdrawal(decimal amount)
        {
            if (this.CustomerType == EnumCustomerType.Individual && amount > 500)  //individual account has withdrawal limit of $500
                return false;
            else
                return true;
        }
    }
}
