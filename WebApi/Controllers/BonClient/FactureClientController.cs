using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetAll([FromQuery] QueryParametersProduit parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }
            if (parameters.Id is null)
            {
                return StatusCode(500, "Empty");

            }
            if (parameters.IdP > 0)
            {
                return Ok(repository.FactureClientRepo.FindByCondition(x => x.BonLivraisonClient.GrossisteId == parameters.Id&&x.Id==parameters.IdP, includeProperties: parameters.include));
            }
            return Ok(repository.FactureClientRepo.FindByCondition(x => x.BonLivraisonClient.GrossisteId == parameters.Id, includeProperties: parameters.include));

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
                            stockProduit.Quantite += item.Quantite;
                            stockProduit.PrixTotaleTTc += item.MontantTTc;
                            stockProduit.PrixTotaleHt += item.MontantHt;
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
    }
}
public class QueryParametersFac
{
    public string Id { get; set; }
    public string include { get; set; }
}