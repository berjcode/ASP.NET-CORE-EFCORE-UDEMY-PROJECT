using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Presentation.Extensions;
using AdvertisementApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvertisementApp.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServiceService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> Advertisement()
        {
           var response = await _advertisementService.GetActiveAsync();
            return this.ResponseView(response);
        }

       
    }
}