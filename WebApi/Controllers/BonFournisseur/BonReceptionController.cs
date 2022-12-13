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
                    //entity.PrixTotaleHt += detail.MontantHt;
                    //entity.PrixTotaleTTc += detail.MontantTTc;
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

            if (parameters.Id == null)
            {
                return StatusCode(500, "Empty");

            }
            if (parameters.iDC < 1)
            {
                return Ok(repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));

            }
            return Ok(repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id && x.FournisseurId == parameters.iDC, includeProperties: parameters.include));
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste,FactureFournisseur.DetailsFactures").FirstOrDefaultAsync();
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
                var bon = await repository.BonDeReceptionFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsReceptions").FirstOrDefaultAsync();
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
                var listjoin = model.DetailsBonReceptionModels.GroupJoin(
                                            bon.DetailsReceptions,
                                            detail => detail.IdProduit,
                                            bon => bon.IdProduit,
                                            (detail, y) => new
                                            {
                                                idProduit = detail.IdProduit,
                                                idBon = detail.IdBonReception,
                                                quantite = detail?.Quantite,
                                                produit = repository.ProduitRepo.GetById(detail.IdProduit),
                                                details = y,
                                            }
                                            );
                var listExept = bon.DetailsReceptions.Select(x => x.IdProduit).Except(model.DetailsBonReceptionModels.Select(x => x.IdProduit)).ToList();
                bon.DetailsReceptions = bon.DetailsReceptions.Where(x => (!listExept.Contains(x.IdProduit))).ToList();
                foreach (var item in listjoin)
                {
                    if (item.details.ToList().Count < 1)
                    {
                        var detail = new DetailsReceptionFournisseur
                        {
                            IdProduit = item.idProduit,
                            IdBonReception = id,
                            MontantHt = item.produit.PriceHt * item.quantite,
                            MontantTTc = item.produit.PriceTTc * item.quantite,
                            Quantite = item.quantite,
                        };
                        bon.DetailsReceptions.Add(detail);
                    }
                    else
                    {
                        item.details.FirstOrDefault().MontantHt = item.produit.PriceHt * item.quantite;
                        item.details.FirstOrDefault().MontantTTc = item.produit.PriceTTc * item.quantite;
                        item.details.FirstOrDefault().Quantite = item.quantite;
                    }

                }

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
                var bon = await repository.BonDeReceptionFournisseurRepo.
                    FindByCondition(
                    x => x.Id == id, includeProperties: "DetailsReceptions.Produit,Fournisseur.Grossiste.Stocks,FactureFournisseur.DetailsFactures")
                    .FirstOrDefaultAsync();
                bon.Confirmed = true;
                repository.BonDeReceptionFournisseurRepo.Update(bon);
                var facture = new FactureFournisseur
                {
                    Date = bon.Date,
                    BonDeReceptionFournisseur = bon,
                   
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
                        var stockEntry = new StockProduitEntry {
                            Quantity = item.Quantite,
                            DateOfEntry=bon.Date
                        };
                        var list = new Collection<StockProduitEntry>();
                        list.Add(stockEntry);
                        var entity = new StockProduit
                        {
                            IdProduit = item.IdProduit,
                            IdStock = bon.Grossiste.Stocks.FirstOrDefault().Id,
                         
                            Produit = item.Produit,
                            Stock = bon.Grossiste.Stocks.FirstOrDefault()

                        };
                        entity.StockProduitEntries = list;
                        repository.StockProduitRepo.Create(entity);
                    }
                    else
                    {
                       
                        var stockEntry = new StockProduitEntry
                        {
                            Quantity = item.Quantite,
                            DateOfEntry = bon.Date
                        };
                        if (stockProduit.StockProduitEntries == null)
                        {
                            var list = new Collection<StockProduitEntry>();
                            list.Add(stockEntry);
                            stockProduit.StockProduitEntries = list;
                        }
                        else
                        {
                            stockProduit.StockProduitEntries.Add(stockEntry);

                        }
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
