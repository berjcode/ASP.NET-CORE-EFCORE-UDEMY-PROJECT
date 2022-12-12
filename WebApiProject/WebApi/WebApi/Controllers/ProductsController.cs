﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {

        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository= repository;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
           var result = await _repository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var data =await _repository.GetByIdAsync(id);
            if(data == null )
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {

            var addedProduct = await _repository.Create(product);
            return Created(string.Empty, product);
        }


        [HttpPut]

        public  async Task<IActionResult> Update(Product product)
        {
           var checkProduct = await  _repository.GetByIdAsync(product.Id);
            if(checkProduct == null)
            {
                return NotFound(product.Id);
            }
            await _repository.UpdateAsync(product);
            return NoContent();
                
                
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkProduct = await _repository.GetByIdAsync(id);
            if (checkProduct == null)
            {
                return NotFound(id);
            }
            await _repository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            var newName= Guid.NewGuid() + "."+Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path,FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty,formFile);
        }

    }
}
