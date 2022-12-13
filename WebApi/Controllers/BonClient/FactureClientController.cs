using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.BonClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureClientController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public FactureClientController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        [Authorize]
        [HttpGet()]
        public IActionResult GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }
            if (!parameters.include.ToLower().Contains("BonLivraisonClient".ToLower()))
            {
                parameters.include = "BonLivraisonClient";
            }

            if (parameters.Id == null)
            {
                return StatusCode(500, "Empty");

            }
            if (parameters.iDC < 1)
            {
                return Ok(repository.FactureClientRepo.FindByCondition(x => x.BonLivraisonClient.GrossisteId == parameters.Id, includeProperties: parameters.include));

            }

            return Ok(repository.FactureClientRepo.FindByCondition
                (x => x.BonLivraisonClient.GrossisteId == parameters.Id
            && x.BonLivraisonClient.ClientId == parameters.iDC, includeProperties: parameters.include));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var facture = await repository.FactureClientRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsFactures.Produit,BonLivraisonClient").FirstOrDefaultAsync();
                if (facture == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var item in facture.DetailsFactures)
                    {
                        var stockProduit = await repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.Stock.Grossiste.Id == facture.BonLivraisonClient.GrossisteId).FirstOrDefaultAsync();
                        if (stockProduit != null)
                        {
                           
                            //stockProduit.PrixTotaleTTc += item.MontantTTc;
                            //stockProduit.PrixTotaleHt += item.MontantHt;
                        }
                        repository.StockProduitRepo.Update(stockProduit);
                    }
                    var bon = await repository.BonLivraisonClientRepo.FindById(facture.BonLivraisonId);
                    bon.Confirmed = false;
                    repository.BonLivraisonClientRepo.Update(bon);
                    repository.FactureClientRepo.Delete(facture);
                    await repository.SaveAsync();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<FactureClient>> Details(int id)
        {
            var Entity = await repository.FactureClientRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "BonLivraisonClient.Grossiste,BonLivraisonClient.Client,DetailsFactures,BonLivraisonClient.DetailsLivraisons.Produit"
                ).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;


        }
    }
}
public class QueryParametersFac
{
    public string Id { get; set; }
    public string include { get; set; }
}