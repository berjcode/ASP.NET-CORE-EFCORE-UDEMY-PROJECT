using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        /*
     
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;*/
        private readonly IRepository<User> _userRepository;
        public HomeController(IRepository<User> userRepository)
        {
           
            _userRepository = userRepository;
           
        }

        public IActionResult Index()
        {
            return View (_userRepository.GetAll(
               
                ));
        }
    }
}
