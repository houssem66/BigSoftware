using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;

        public StockController(IStockService _StockService)
        {
            stockService = _StockService;
        }
        //[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Stock>> PostClient([FromBody] Stock model)
        {
            {
                if (ModelState.IsValid)
                {
                    try { await stockService.Ajout(model); }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }


                    return CreatedAtAction("Details", new { id = model.Id }, model);
                }
            }

            return Ok(StatusCode(400));
        }

        //[Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (stockService.GetAll().AsQueryable());
        }
        //[Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await stockService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        //[Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update( int id, [FromBody] Stock entity)
        {
            try
            {
                await stockService.Update(entity.Id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception e)
            {

                return Ok(StatusCode(400));
            }


        }
        //[Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Stock>> Details(int id)
        {
            var Entity = await stockService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
