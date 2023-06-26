using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Linq;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(context.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var value = context.Categories.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);

            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            context.Add(category);
            context.SaveChanges();
            return Created("", category); // fonksiyonun geri dönüş değerini ifade eder
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = context.Categories.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(value);
                context.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]   
        public IActionResult CategoryUpdate(Category category)
        {
            var value = context.Find<Category>(category.CategoryID);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = category.CategoryName;
                context.Update(value);
                context.SaveChanges();
                return NoContent();
            }
        }
    }
}
