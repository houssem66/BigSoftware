using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public ProduitController(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Produit>> PostProduit(string id, [FromBody] ProduitModel model)
        {
            var entity = mapper.Map<Produit>(model);
            entity.IdGrossiste = id;
            if (ModelState.IsValid)
            {



                //var y = ((decimal)model.TVA);
                //var x = model.PriceHt * (y / 100) + model.PriceHt;
                //entity.PriceTTc = x;

                try
                {
                    repository.ProduitRepo.Create(entity);
                    await repository.SaveAsync();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(StatusCode(400));
                }


                return CreatedAtAction("Details", new { id = entity.Id }, entity);
            }
            model.Message = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToString();



            return BadRequest(model.Message);
        }

        //[Authorize]
        [HttpGet()]
        public IQueryable GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }

            return (repository.ProduitRepo.FindByCondition(x => x.IdGrossiste == parameters.Id, includeProperties: parameters.include));
        }
        //[Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await repository.ProduitRepo.FindById(id);
                repository.ProduitRepo.Delete(entity);
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
        public async Task<IActionResult> Update(int id, [FromBody] ProduitModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Message = ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToString();
                return BadRequest(model.Message);
            }
            var entity = await repository.ProduitRepo.FindById(id);

            try
            {
                mapper.Map(model, entity);
                repository.ProduitRepo.Update(entity);
                await repository.SaveAsync();
                return Ok(StatusCode(200));
            }
            catch (Exception)
            {
                return Ok(StatusCode(400));
            }
        }
        //[Authorize]
        [HttpGet("Get")]
        public async Task<ActionResult<Produit>> Details([FromQuery] QueryParametersInt parameters)
        {
            var Entity = await repository.ProduitRepo.FindById(parameters.Id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
