using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.BonFournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureFournisseurController : ControllerBase
    {
        private readonly IFactureFournisseurService factureFournisseurService;
        private readonly IStockProduitService stockProduitService;
        private readonly IBonDeReceptionFournisseurService bonDeReceptionFournisseurService;

        public FactureFournisseurController(IFactureFournisseurService factureFournisseurService ,IStockProduitService stockProduitService,IBonDeReceptionFournisseurService bonDeReceptionFournisseurService)
        {
            this.factureFournisseurService = factureFournisseurService;
            this.stockProduitService = stockProduitService;
            this.bonDeReceptionFournisseurService = bonDeReceptionFournisseurService;
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<FactureFournisseur>> Details(int id)
        {
            var Entity = await factureFournisseurService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
        [Authorize]
        [HttpGet("{id}")]
        public IQueryable GetAll(string id)
        {


            return factureFournisseurService.GetAll(id).AsQueryable();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var facture = await factureFournisseurService.GetById(id);
            var bon = await bonDeReceptionFournisseurService.GetById(facture.BonDeReceptionId, "DetailsReceptions");
            foreach (var item in facture.DetailsFactures)
            {
                var stockProduit = new StockProduit
                {
                    IdProduit = item.IdProduit,
                    IdStock = facture.BonDeReceptionFournisseur.Grossiste.Stocks.FirstOrDefault().Id,
                    PrixTotaleHt = item.MontantHt,
                    PrixTotaleTTc = item.MontantTTc,
                    Quantite = item.Quantite,
                    Produit = item.Produit,
                    Stock = facture.BonDeReceptionFournisseur.Grossiste.Stocks.FirstOrDefault()

                };
                try
                {
                    
                    await stockProduitService.Diminuer(stockProduit.IdProduit, stockProduit.IdStock, stockProduit);
                }
                catch (Exception e)
                {
                    return Ok(StatusCode(400));
                }

            }

            try
            {
                bon.Confirmed = false;
                await bonDeReceptionFournisseurService.Update(bon.Id, bon);
                await factureFournisseurService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
    }
}
