using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.BonFournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureFournisseurController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public FactureFournisseurController(IRepositoryWrapper repository)
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
            if (parameters.Id is null)
            {
                return StatusCode(500, "Empty");

            }
            return Ok(repository.FactureFournisseurRepo.FindByCondition(x => x.BonDeReceptionFournisseur.GrossisteId == parameters.Id, includeProperties: parameters.include));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var facture = await repository.FactureFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsFactures.Produit,BonDeReceptionFournisseur").FirstOrDefaultAsync();
                if (facture == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var item in facture.DetailsFactures)
                    {
                        var stockProduit = await repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.Stock.Grossiste.Id == facture.BonDeReceptionFournisseur.GrossisteId).FirstOrDefaultAsync();
                        if (stockProduit != null)
                        {
                            stockProduit.Quantite -= item.Quantite;
                            stockProduit.PrixTotaleTTc -= item.MontantTTc;
                            stockProduit.PrixTotaleHt -= item.MontantHt;
                        }
                        repository.StockProduitRepo.Update(stockProduit);
                    }
                    var bon = await repository.BonDeReceptionFournisseurRepo.FindById(facture.BonDeReceptionId);
                    bon.Confirmed = false;
                    repository.BonDeReceptionFournisseurRepo.Update(bon);
                    repository.FactureFournisseurRepo.Delete(facture);
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
