using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingAccounts.API.Data;
using StreamingAccounts.Shared.Entities;

namespace StreamingAccounts.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController :ControllerBase
    {
        private readonly DataContext _context;


        public CategoriesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Categories.ToListAsync());

        }




        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
    }
}
