using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using AdvertisementApp.Presentation.Extensions;
using AdvertisementApp.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AdvertisementApp.Presentation.Controllers
{
    public class AdvertisementApp : Controller
    {

        private readonly IAppUserService _appUserService;



        private readonly IAdvertisementAppUserService _advertisementAppUserService;

        public AdvertisementApp(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            //User Id alıyoruz. İlan Id önceden alındı ve parametreo larak geldi
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
          // var user = userResponse.Data;
          //Askerlik Bilgisi
            var items = Enum.GetValues(typeof(MilitaryStatusType));

            var list = new List< MilitaryStatusListDto > ();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id= item,
                    Definition =Enum.GetName(typeof(MilitaryStatusType),item),
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
            ViewBag.GenderId = userResponse.Data.GenderId;
            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            }) ;
        }

        [Authorize(Roles ="Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();


            if(model.CvFile != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName= Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","cvFiles",fileName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);
                dto.CvPath =path;

            }

            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId= model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate= model.EndDate;
            dto.MilitaryStatusId =model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;
              var response =await   _advertisementAppUserService.CreateAsync(dto);
            // return this.ResponseRedirectAction(response, "Advertisement","Home");

            if(response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach(var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                }
                //Genderı hatadan sorna tekrar getirmeye yarar.
                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
                ViewBag.GenderId = userResponse.Data.GenderId;
                var items = Enum.GetValues(typeof(MilitaryStatusType));

                var list = new List<MilitaryStatusListDto>();

                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                    });
                }

                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
                return View(model);
            }
            else
            {
                return RedirectToAction("Advertisement","Home");
            }
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Basvurdu);
            return View(list);
        }


        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {

            await _advertisementAppUserService.SetStatus(advertisementAppUserId, type);

            return RedirectToAction("List");
        }

        [Authorize(Roles ="Admin")]
       public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Mulakat);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Olumsuz);
            return View(list);
        }



        public async Task<IActionResult> Remove(int id)
        {

            var response = await _advertisementAppUserService.RemoveAsync(id);
            return this.ResponseRedirectAction(response, "List");
        }
    }



}
