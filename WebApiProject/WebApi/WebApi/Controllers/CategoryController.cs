using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/controller")]
    public class CategoryController:ControllerBase
    {

        private readonly ProductContext _context;

        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]

        public IActionResult GetWithProduct(int id)
        {
            var data = _context.Categories.Include(x=>x.Products).SingleOrDefault(x=>x.Id == id);

            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
