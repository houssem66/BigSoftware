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
    public class BonLivraisonController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositoryWrapper repository;

        public BonLivraisonController(IMapper mapper, IRepositoryWrapper repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonLivraisonClient>> PostBonDeReceptionFournisseur([FromBody] BonLivraisonViewModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest(" model object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var entity = mapper.Map<BonLivraisonClient>(model);
                entity.DetailsLivraisons = new Collection<DetailsLivraisonClient>();
                entity.PrixTotaleTTc = 0;
                entity.PrixTotaleHt = 0;
                foreach (var item in model.DetailsLivraisonsModel)
                {
                   
                        var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                        if (produit != null)
                        {
                            var detail = new DetailsLivraisonClient
                            {
                                IdProduit = produit.Id,
                                IdBonLivraison = entity.Id,
                                MontantHt = produit.PriceHt * item.Quantite,
                                MontantTTc = produit.PriceTTc * item.Quantite,
                                Quantite = item.Quantite,
                            };
                            entity.DetailsLivraisons.Add(detail);
                            entity.PrixTotaleHt +=produit.PriceHt * item.Quantite;
                            entity.PrixTotaleTTc += produit.PriceTTc * item.Quantite;
                        }               
                }
              
                repository.BonLivraisonClientRepo.Create(entity);
                try
                {
                    await repository.SaveAsync();

                }
                catch (Exception e)
                {
                    return StatusCode(500, "Internal server " + e.Message);
                }
                return CreatedAtAction("Details", new { id = entity.Id }, entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Interna server error" + e.Message);
            }
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<BonLivraisonClient>> Details(int id)
        {
            var Entity = await repository.BonLivraisonClientRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "DetailsLivraisons.Produit,Client,Grossiste,FactureClient.DetailsFactures"
                ).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;


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
                return Ok(repository.BonLivraisonClientRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));
            }
            return StatusCode(500, "Empty");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.BonLivraisonClientRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsLivraisons.Produit,Client,Grossiste,FactureClient.DetailsFactures").FirstOrDefaultAsync();
                if (bon == null)
                {
                    return NotFound();
                }
                else
                {
                    if (bon.Confirmed)
                    {
                        foreach (var item in bon.DetailsLivraisons)
                        {
                            var stockProduit = await repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.Stock.Grossiste.Id == bon.GrossisteId).FirstOrDefaultAsync();
                            if (stockProduit != null)
                            {
                                stockProduit.Quantite += item.Quantite;
                                stockProduit.PrixTotaleTTc += item.MontantTTc;
                                stockProduit.PrixTotaleHt += item.MontantHt;
                            }
                            repository.StockProduitRepo.Update(stockProduit);
                        }
                        repository.BonLivraisonClientRepo.Delete(bon);
                    }
                    else
                    {
                        repository.BonLivraisonClientRepo.Delete(bon);
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
        public async Task<IActionResult> Update(int id, [FromBody] BonLivraisonViewModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest(" model object is null");
                }
                var bon = await repository.BonLivraisonClientRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsLivraisons.Produit,Client,Grossiste,FactureClient.DetailsFactures").FirstOrDefaultAsync();
                if (bon is null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                mapper.Map(model, bon);
                var list = new List<DetailsLivraisonClient>();
                bon.PrixTotaleTTc = 0;
                bon.PrixTotaleHt = 0;
                foreach (var item in model.DetailsLivraisonsModel)
                {
                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    var detail = new DetailsLivraisonClient
                    {
                        IdProduit = produit.Id,
                        IdBonLivraison = id,
                        MontantHt = produit.PriceHt * item.Quantite,
                        MontantTTc = produit.PriceTTc * item.Quantite,
                        Quantite = item.Quantite,
                        Produit = produit
                    };
                    bon.PrixTotaleTTc += detail.MontantTTc;
                    bon.PrixTotaleHt += detail.MontantHt;
                    list.Add(detail);
                }
                bon.DetailsLivraisons = list;

                repository.BonLivraisonClientRepo.Update(bon);
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
        public async Task<IActionResult> Confirmer([FromQuery] int id)
        {
            if (id <= 0)
            {
                return Ok(StatusCode(400));
            }
            else
            {
                var bon = await repository.BonLivraisonClientRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsLivraisons.Produit,Client,Grossiste,FactureClient.DetailsFactures").FirstOrDefaultAsync();
                bon.Confirmed = true;
                repository.BonLivraisonClientRepo.Update(bon);
                var facture = new FactureClient
                {
                    Date = bon.Date,
                    BonLivraisonClient = bon,
                    PrixTotaleHt = bon.PrixTotaleHt,
                    PrixTotaleTTc = bon.PrixTotaleTTc,
                };
                facture.DetailsFactures = new Collection<DetailsFactureClient>();
                foreach (var item in bon.DetailsLivraisons)
                {
                    var detailsFacture = new DetailsFactureClient
                    {
                        MontantHt = item.MontantHt,
                        MontantTTc = item.MontantTTc,
                        IdProduit = item.IdProduit,
                        Quantite = item.Quantite
                    };
                    facture.DetailsFactures.Add(detailsFacture);
                    var stockProduit = repository.StockProduitRepo.FindByCondition(x => x.IdProduit == item.IdProduit && x.Stock.Grossiste.Id == bon.GrossisteId).FirstOrDefault();
                    if (stockProduit == null)
                    {
                        return BadRequest(" produit object is null");
                    }
                    else
                    {if ((stockProduit.PrixTotaleTTc- item.MontantTTc<0)&& (stockProduit.PrixTotaleTTc - item.MontantTTc < 0)&& (stockProduit.Quantite - item.Quantite < 0))
                        {
                            return BadRequest("a negative was returned");
                        }
                            stockProduit.PrixTotaleTTc -= item.MontantTTc;
                        stockProduit.PrixTotaleHt -= item.MontantHt;
                        stockProduit.Quantite -= item.Quantite;
                        repository.StockProduitRepo.Update(stockProduit);
                    }
                }

                repository.FactureClientRepo.Create(facture);
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
    }
}
