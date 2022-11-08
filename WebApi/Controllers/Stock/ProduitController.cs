using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
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
        private readonly IProduitService produitService;

        public ProduitController(IRepositoryWrapper repository, IMapper mapper, IProduitService produitService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.produitService = produitService;
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
        public IQueryable GetAll([FromQuery] QueryParametersProduit parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }
            if (parameters.IdP > 0)
            {
                return (repository.ProduitRepo.FindByCondition(x => x.IdGrossiste == parameters.Id && x.Id == parameters.IdP, includeProperties: parameters.include).AsSplitQuery());
            }

            return (repository.ProduitRepo.FindByCondition(x => x.IdGrossiste == parameters.Id , includeProperties: parameters.include).AsSplitQuery());
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
            var entity = await repository.ProduitRepo.FindByCondition(x => x.Id == id,
                includeProperties:
                "StockProduit,DetailsCommandes,DetailsFactures,DetailsReceptions,DetailsFactureClients,DetailsCommandeClients,DetailsLivraisons,DetailsDevis,DetailsBonSorties")

                .FirstOrDefaultAsync();

            try
            {
                // entity.DetailsDevis.().FirstOrDefault().MontantTTc=entity.PriceTTc * entity.DetailsDevis.FirstOrDefault().Quantite;
            
                mapper.Map(model, entity);
                await produitService.UpdateAll(entity);
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
public class QueryParametersProduit
{
    public string Id { get; set; }
    public int IdP { get; set; }
    public string include { get; set; }
}