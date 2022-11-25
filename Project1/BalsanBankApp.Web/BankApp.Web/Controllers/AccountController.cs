using BankApp.Web.Data.Context;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _context.Users.Select(x=> new UserListModel
            {
                Id= x.Id,
                Name=x.Name,
                Surname=x.Surname,
            }).SingleOrDefault(x => x.Id == id);
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {

            _context.Accounts.Add(new Data.Entities.Account
            { 
                AccountNumber= model.AccountNumber,
                UserID= model.UserID,
                Balance= model.Balance,

            });
            _context.SaveChanges();
            return RedirectToAction("Index","Home");

        }
    }
}
