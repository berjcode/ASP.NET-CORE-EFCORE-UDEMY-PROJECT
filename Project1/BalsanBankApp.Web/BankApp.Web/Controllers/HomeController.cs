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

        private readonly BankContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(BankContext context,IUserRepository userRepository, IUserMapper userMapper)
        {
            _context = context;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View ( _userMapper.MapToIfUserList(_userRepository.GetAll()));
        }
    }
}
