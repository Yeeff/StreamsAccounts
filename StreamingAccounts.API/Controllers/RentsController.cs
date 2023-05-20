using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingAccounts.API.Data;
using StreamingAccounts.Shared.DTOs;
using StreamingAccounts.Shared.Entities;

namespace StreamingAccounts.API.Controllers
{
    [ApiController]
    [Route("/api/rents")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RentsController : ControllerBase
    {
        private readonly DataContext _context;


        public RentsController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.ProductRents.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Post(ProductRent productRent)
        {
            _context.Add(productRent);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(productRent);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un alquilar igual.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var productRent = await _context.ProductRents
              .Include(x => x.Product!)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productRent is null)
            {
                return NotFound();
            }

            return Ok(productRent);
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.ProductRents
                .Include(x => x.Product!)
                .ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult> Put(ProductRent productRent)
        {
            _context.Update(productRent);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(productRent);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.ProductRents
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
