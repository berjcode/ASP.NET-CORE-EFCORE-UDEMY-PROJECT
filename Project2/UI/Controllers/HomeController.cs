using AutoMapper;
using Business.Interfaces;
using Business.Mappings;
using Dtos.WorkDtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkServices _workServices;

        /*   private readonly IMapper _mapper;  IDto Interface sayesinde yazmamıza gerek kalmadı. Generic Yapı*/

        public HomeController(IWorkServices workServices)
        {
            _workServices = workServices;

        }

        public async Task<IActionResult> Index()
        {
            var response = await _workServices.GetAll();
            return View(response.Data);


            //var workList = await _workServices.GetAll();
            //return View(workList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {

           var response = await _workServices.Create(dto);
           if(response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(dto);
              
            }else
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Update(int id)
        {
            //ResponseObject Sonrası 
            var response = await _workServices.GetById<WorkUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }

            return View(response.Data);

            //AutoMapperSonrası

            //return View(await _workServices.GetById<WorkUpdateDto>(id));

            //AutoMapper Öncesi

            //return View(new WorkUpdateDto
            //{
            //    Id= dto.Id,
            //    Definition = dto.Definition,
            //    IsCompleted = dto.IsCompleted,
            //});
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {

            var response = await _workServices.Update(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
                return View(dto);
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Remove(int id)
        {
          var response =  await _workServices.Remove(id);

            if(response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return RedirectToAction("Index");
        }


        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}