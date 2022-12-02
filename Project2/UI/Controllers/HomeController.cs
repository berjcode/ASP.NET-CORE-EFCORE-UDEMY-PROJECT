using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkServices _workServices;

        public HomeController(IWorkServices workServices)
        {
            _workServices = workServices;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workServices.GetAll();
            return View(workList);
        }


    }
}