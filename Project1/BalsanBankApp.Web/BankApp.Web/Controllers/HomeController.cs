using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

     
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(IUserRepository userRepository, IUserMapper userMapper)
        {
           
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View ( _userMapper.MapToIfUserList(_userRepository.GetAll()));
        }
    }
}
