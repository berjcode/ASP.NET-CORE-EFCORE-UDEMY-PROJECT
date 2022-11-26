using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountMapper _accountMapper;

  

        public AccountController( IUserRepository userRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        {
           
            _userRepository = userRepository;
            _userMapper = userMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _userMapper.MapToUserList(_userRepository.GetById(id));
            return View(userInfo);

            /*  var userInfo =   _context.Users.Select(x=> new UserListModel
            {
                Id= x.Id,
                Name=x.Name,
                Surname=x.Surname,
            }).SingleOrDefault(x => x.Id == id); */
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
           _accountRepository.Create(_accountMapper.Map(model));

        
            return RedirectToAction("Index","Home");

        }
    }
}

/*
_context.Accounts.Add(new Data.Entities.Account
{ 
    AccountNumber= model.AccountNumber,
    UserID= model.UserID,
    Balance= model.Balance,

});*/