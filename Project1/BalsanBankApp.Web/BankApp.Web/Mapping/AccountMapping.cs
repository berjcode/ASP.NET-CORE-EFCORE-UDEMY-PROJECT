using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class AccountMapping:IAccountMapper
    {

        public Account Map( AccountCreateModel model) 
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                UserID = model.UserID,
            };
        
        }
    }
}
