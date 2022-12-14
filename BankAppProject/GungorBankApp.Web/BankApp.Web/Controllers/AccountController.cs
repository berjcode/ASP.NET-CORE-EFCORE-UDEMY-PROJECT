using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {/*
       
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
        }*/

        //private readonly IRepository<Account> _accountRepository;
        //private readonly IRepository<User> _userRepository;

        //public AccountController (IRepository<Account> accountrepository,IRepository<User> usserRepository)
        //{
        //    _accountRepository= accountrepository;
        //    _userRepository= usserRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _unitOfWork.GetRepository<User>().GetByID(id);
            return View(new UserListModel
            {
                Id= id,
                Name = userInfo.Name,
                Surname= userInfo.Surname,
            });

            //_userMapper.MapToUserList(_userRepository.GetById(id));
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
            _unitOfWork.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                UserID = model.UserID,
            });

            _unitOfWork.SaveChanges();
            return RedirectToAction("Index","Home");

        }


        [HttpGet]
        public IActionResult GetByUserID(int id)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryAble();
           var accountlist=  query.Where(x=> x.UserID == id ).ToList();
            var user = _unitOfWork.GetRepository<User>().GetByID(id);
            ViewBag.FullName = user.Name + "  " + user.Surname;
            var list = new List<AccountListModel>();
           foreach (var account in accountlist)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    UserId= account.UserID,
                    Balance = account.Balance,
                   // FullName = user.Name +" "+ user.Surname,
                    Id= account.Id
                });
            }
           return View(list);
        }


        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryAble();
            var accounts = query.Where(x=> x.Id != accountId).ToList();
         

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach(var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    UserId = account.UserID,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            
            return View(new SelectList(list,"Id", "AccountNumber"));
        }


        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _unitOfWork.GetRepository<Account>().GetByID(model.SenderId);
            senderAccount.Balance -= model.Amount;

            _unitOfWork.GetRepository<Account>().Update(senderAccount);

            var account = _unitOfWork.GetRepository<Account>().GetByID(model.AccountId);
            account.Balance += model.Amount;
            _unitOfWork.GetRepository<Account>().Update(account);

            _unitOfWork.SaveChanges();


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