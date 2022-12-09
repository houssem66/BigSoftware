using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public StockController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        //[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Stock>> PostClient([FromBody] Stock model)
        {
            {
                if (ModelState.IsValid)
                {
                    try { repository.StockRepo.Create(model);
                      await  repository.SaveAsync();
                    }

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
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await repository.StockRepo.FindById(id);
                repository.StockRepo.Delete(entity);
                await repository.SaveAsync();

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        //[Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Stock entity)
        {
            if (entity != null)
            {
                try
                {

                    repository.StockRepo.Update(entity);
                    await repository.SaveAsync();

                    return Ok(StatusCode(200));


                }
                catch (Exception e)
                {

                    return Ok(StatusCode(400));
                }
            }
            return Ok(StatusCode(400));
        }
        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<Stock>> GetAll([FromQuery] QueryParametersString parameters)
        {
            
            try
            {
                if (parameters.include == null)
                {
                    parameters.include = "";
                }
                var entity = await repository.StockRepo.FindByCondition(x => x.Grossiste.Id == parameters.Id, includeProperties: parameters.include).FirstOrDefaultAsync();
                if (entity == null)
                {
                    return NotFound();
                }
                return entity;

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

           

        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Stock>> Details(int id)
        {
            var Entity = await repository.StockRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "StockProduit.Produit,Grossiste"
                ).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;


        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Stock>> CalculateInventory(int id)
        {
            var Entity = await repository.StockRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "StockProduit.Produit,Grossiste"
                ).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;


        }
    }
}
public class QueryParametersStock
{
    public string IdG { get; set; }
    public string IdP { get; set; }
    public string include { get; set; }
}