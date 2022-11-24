using System.Security.Principal;

namespace BankApp.Web.Data.Entities
{
    public class Account
    {

        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
    }
}
