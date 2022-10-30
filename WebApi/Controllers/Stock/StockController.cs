using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IQueryable GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }

            return (repository.StockRepo.FindByCondition(x => x.Grossiste.Id == parameters.Id, includeProperties: parameters.include));
        }
    }
}
