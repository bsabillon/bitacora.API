using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bitacora.API.Data;
using Microsoft.EntityFrameworkCore;
using bitacora.API.Models;

namespace bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase 
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
            
        }
        
         [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return category;
        }


        [HttpPost]
        public async Task<ActionResult<Category>>PostCategory(Category item)
        {

            

            _context.Categories.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { Id = item.id }, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category==null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();

        }





}
}