using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockProduitController : ControllerBase
    {
        private readonly IStockProduitService stockProduitService;

        public StockProduitController(IStockProduitService _StockProduitService)
        {
            stockProduitService = _StockProduitService;
        }
        //[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<StockProduit>> PostClient([FromBody] StockProduit model)
        {
            {
                if (ModelState.IsValid)
                {
                    try { await stockProduitService.Ajout(model); }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }


                    return CreatedAtAction("Details", new { idProduit = model.IdProduit,idStock=model.IdStock }, model);
                }
            }

            return Ok(StatusCode(400));
        }

        //[Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (stockProduitService.GetAll().AsQueryable());
        }
        //[Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await stockProduitService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        //[Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, StockProduit entity)
        {
            try
            {
                await stockProduitService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }


        }
        //[Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<StockProduit>> Details(int id)
        {
            var Entity = await stockProduitService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
