using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonReceptionController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public BonReceptionController(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //  [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> PostBonDeReceptionFournisseur([FromBody] BonReceptionModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<BonDeReceptionFournisseur>(model);
                entity.DetailsReceptions = new Collection<DetailsReceptionFournisseur>();
                foreach (var item in model.DetailsBonReceptionModels)
                {
                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    var detail = new DetailsReceptionFournisseur
                    {
                        IdProduit = produit.Id,
                        IdBonReception = entity.Id,
                        MontantHt = produit.PriceHt * item.Quantite,
                        MontantTTc = produit.PriceTTc * item.Quantite,
                        Quantite = item.Quantite,
                    };
                    entity.DetailsReceptions.Add(detail);
                    entity.PrixTotaleHt += detail.MontantHt;
                    entity.PrixTotaleTTc += detail.MontantTTc;
                }
                try
                {
                    repository.BonDeReceptionFournisseurRepo.Create(entity);
                    await repository.SaveAsync();
                    return CreatedAtAction("Details", new { id = entity.Id }, entity);
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }
            }

            return Ok(StatusCode(400));
        }

        [Authorize]
        [HttpGet()]
        public IActionResult GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }
            if (parameters.Id != null)
            {
                return Ok(repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));
            }
            return StatusCode(500, "Empty");
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste.Stocks").FirstOrDefaultAsync();
                if (bon == null)
                {
                    return NotFound();
                }
                else
                {
                    if (bon.Confirmed)
                    {
                        foreach (var item in bon.DetailsReceptions)
                        {
                            var stockProduit = await repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.Stock.Grossiste.Id == bon.GrossisteId).FirstOrDefaultAsync();
                            if (stockProduit != null)
                            {
                                stockProduit.Quantite -= item.Quantite;
                                stockProduit.PrixTotaleTTc -= item.MontantTTc;
                                stockProduit.PrixTotaleHt -= item.MontantHt;
                            }
                            repository.StockProduitRepo.Update(stockProduit);
                        }
                        repository.BonDeReceptionFournisseurRepo.Delete(bon);
                    }
                    else
                    {
                        repository.BonDeReceptionFournisseurRepo.Delete(bon);
                    }

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
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BonReceptionModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest(" model object is null");
                }
                var bon = await repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste.Stocks,FactureFournisseur.DetailsFactures").FirstOrDefaultAsync();
                if (bon is null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                mapper.Map(model, bon);
                var list = new List<DetailsReceptionFournisseur>();

                foreach (var item in model.DetailsBonReceptionModels)
                {
                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    var detail = new DetailsReceptionFournisseur
                    {
                        IdProduit = produit.Id,
                        IdBonReception = id,
                        MontantHt = produit.PriceHt * item.Quantite,
                        MontantTTc = produit.PriceTTc * item.Quantite,
                        Quantite = item.Quantite,
                        Produit = produit
                    };
                    bon.PrixTotaleTTc += detail.MontantTTc;
                    bon.PrixTotaleHt += detail.MontantHt;
                    list.Add(detail);
                }
                bon.DetailsReceptions = list;

                repository.BonDeReceptionFournisseurRepo.Update(bon);
                await repository.SaveAsync();


                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }



        }
        [Authorize]
        [HttpPut("Confirmer")]
        public async Task<IActionResult> ConfirmerBonReception([FromQuery] int id)
        {
            if (id <= 0)
            {
                return Ok(StatusCode(400));
            }
            else
            {
                var bon = await repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste.Stocks,FactureFournisseur.DetailsFactures").FirstOrDefaultAsync();
                bon.Confirmed = true;
                repository.BonDeReceptionFournisseurRepo.Update(bon);
                var facture = new FactureFournisseur
                {
                    Date = bon.Date,
                    BonDeReceptionFournisseur = bon,
                    PrixTotaleHt = bon.PrixTotaleHt,
                    PrixTotaleTTc = bon.PrixTotaleTTc,
                };
                facture.DetailsFactures = new Collection<DetailsFactureFournisseur>();
                foreach (var item in bon.DetailsReceptions)
                {
                    var detailsFacture = new DetailsFactureFournisseur
                    {
                        MontantHt = item.MontantHt,
                        MontantTTc = item.MontantTTc,
                        IdProduit = item.IdProduit,
                        Quantite = item.Quantite
                    };
                    facture.DetailsFactures.Add(detailsFacture);
                    var stockProduit = repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.IdStock == bon.Grossiste.Stocks.FirstOrDefault().Id).FirstOrDefault();
                    if (stockProduit == null)
                    {
                        var entity = new StockProduit
                        {
                            IdProduit = item.IdProduit,
                            IdStock = bon.Grossiste.Stocks.FirstOrDefault().Id,
                            PrixTotaleHt = item.MontantHt,
                            PrixTotaleTTc = item.MontantTTc,
                            Quantite = item.Quantite,
                            Produit = item.Produit,
                            Stock = bon.Grossiste.Stocks.FirstOrDefault()

                        };
                        repository.StockProduitRepo.Create(entity);
                    }
                    else
                    {
                        stockProduit.PrixTotaleTTc += item.MontantTTc;
                        stockProduit.PrixTotaleHt += item.MontantHt;
                        stockProduit.Quantite += item.Quantite;
                        repository.StockProduitRepo.Update(stockProduit);
                    }
                }

                repository.FactureFournisseurRepo.Create(facture);
                try
                {
                    await repository.SaveAsync();
                }
                catch (Exception e)
                {
                    return Ok(StatusCode(400, e.Message)); ;
                }
                return Ok(StatusCode(200));

            }


        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> Details(int id)
        {
            var Entity = await repository.BonDeReceptionFournisseurRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste,FactureFournisseur.DetailsFactures"
                ).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;


        }
    }
}
