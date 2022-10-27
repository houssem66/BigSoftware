﻿using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonReceptionController : ControllerBase
    {
        private readonly IBonDeReceptionFournisseurService bonDeReceptionFournisseurService;
        private readonly IProduitService produitService;
        private readonly IDetailsBonDeReceptionFournisseurService detailsBonReceptionService;
        private readonly IGrossisteService grossisteService;
        private readonly IStockProduitService stockProduitService;

        public BonReceptionController(IBonDeReceptionFournisseurService _BonDeReceptionFournisseurService, IProduitService _ProduitService, IDetailsBonDeReceptionFournisseurService _DetailsBonReceptionService, IGrossisteService grossisteService, IStockProduitService stockProduitService)
        {
            bonDeReceptionFournisseurService = _BonDeReceptionFournisseurService;
            produitService = _ProduitService;
            detailsBonReceptionService = _DetailsBonReceptionService;
            this.grossisteService = grossisteService;
            this.stockProduitService = stockProduitService;
        }
        //  [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> PostBonDeReceptionFournisseur([FromBody] BonReceptionModel model)
        {
            {
                var entity = new BonDeReceptionFournisseur
                {
                    Date = model.Date,
                    PrixTotaleHt = model.PrixTotaleHt,
                    PrixTotaleTTc = model.PrixTotaleTTc,
                    FournisseurId = model.FournisseurId,
                    GrossisteId = model.GrossisteId


                };
                if (ModelState.IsValid)
                {
                    try
                    {
                        await bonDeReceptionFournisseurService.Ajout(entity);


                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }
                    var list = new List<DetailsReceptionFournisseur>();
                    Decimal? sumTTc = 0;
                    Decimal? sumHt = 0;
                    var Grossiste = await grossisteService.GetById(model.GrossisteId);
                    foreach (var item in model.DetailsBonReceptionModels)
                    {
                        var produit = await produitService.GetById(item.IdProduit);

                        var detail = new DetailsReceptionFournisseur
                        {
                            IdProduit = produit.Id,
                            IdBonReception = entity.Id,
                            MontantHt = produit.PriceHt * item.Quantite,
                            MontantTTc = produit.PriceTTc * item.Quantite,
                            Quantite = item.Quantite,
                            Produit = produit



                        };
                        sumTTc += detail.MontantTTc;
                        sumHt += detail.MontantHt;
                        list.Add(detail);
                        var stockProduit = new StockProduit
                        {
                            IdProduit = produit.Id,
                            IdStock = Grossiste.Stocks.FirstOrDefault().Id,
                            PrixTotaleHt = detail.MontantHt,
                            PrixTotaleTTc = detail.MontantTTc,
                            Quantite = detail.Quantite,
                            Produit = produit,
                            Stock = Grossiste.Stocks.FirstOrDefault()

                        };
                        try
                        {
                            await stockProduitService.Augmenter(stockProduit.Quantite, stockProduit.IdProduit, stockProduit.IdStock, stockProduit);
                        }
                        catch (Exception e)
                        {
                            return Ok(StatusCode(400));
                        }
                    }
                    entity.DetailsReceptions = list;
                    entity.PrixTotaleTTc = sumTTc;
                    entity.PrixTotaleHt = sumHt;
                    await bonDeReceptionFournisseurService.Update(entity.Id, entity);
                    return CreatedAtAction("Details", new { id = entity.Id }, entity);
                }
            }

            return Ok(StatusCode(400));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IQueryable GetAll(string id)
        {


            return (bonDeReceptionFournisseurService.GetAll(id).AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bon = await bonDeReceptionFournisseurService.GetById(id, "DetailsReceptions");
            foreach (var item in bon.DetailsReceptions)
            {
                var stockProduit = new StockProduit
                {
                    IdProduit = item.IdProduit,
                    IdStock = bon.Grossiste.Stocks.FirstOrDefault().Id,
                    PrixTotaleHt = item.MontantHt,
                    PrixTotaleTTc = item.MontantTTc,
                    Quantite = item.Quantite,
                    Produit = item.Produit,
                    Stock = bon.Grossiste.Stocks.FirstOrDefault()

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
                await bonDeReceptionFournisseurService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] BonReceptionModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new BonDeReceptionFournisseur
                {
                    Date = model.Date,
                    PrixTotaleHt = model.PrixTotaleHt,
                    PrixTotaleTTc = model.PrixTotaleTTc,
                    FournisseurId = model.FournisseurId,
                    GrossisteId = model.GrossisteId,
                    Id = model.Id


                };
                var bon = await bonDeReceptionFournisseurService.GetById(model.Id, "DetailsReceptions");
                foreach (var item in bon.DetailsReceptions)
                {
                    var index = model.DetailsBonReceptionModels.ToList().FindIndex(w => w.IdProduit == item.IdProduit);
                    if (index >= 0)
                    {


                    }
                    else
                    {
                        var stockProduit = new StockProduit
                        {
                            IdProduit = item.IdProduit,
                            IdStock = bon.Grossiste.Stocks.FirstOrDefault().Id,
                            PrixTotaleHt = item.MontantHt,
                            PrixTotaleTTc = item.MontantTTc,
                            Quantite = item.Quantite,
                            Produit = item.Produit,
                            Stock = bon.Grossiste.Stocks.FirstOrDefault()

                        };
                        await stockProduitService.Diminuer(stockProduit.IdProduit, stockProduit.IdStock, stockProduit);

                    }

                }
                var list = new List<DetailsReceptionFournisseur>();
                Decimal? sumTTc = 0;
                Decimal? sumHt = 0;
                var Grossiste = await grossisteService.GetById(model.GrossisteId);
                foreach (var item in model.DetailsBonReceptionModels)
                {
                    var produit = await produitService.GetById(item.IdProduit);

                    var detail = new DetailsReceptionFournisseur
                    {
                        IdProduit = produit.Id,
                        IdBonReception = model.Id,
                        MontantHt = produit.PriceHt * item.Quantite,
                        MontantTTc = produit.PriceTTc * item.Quantite,
                        Quantite = item.Quantite,
                        Produit = produit



                    };
                    sumTTc += detail.MontantTTc;
                    sumHt += detail.MontantHt;
                    list.Add(detail);
                    var stockProduit = new StockProduit
                    {
                        IdProduit = produit.Id,
                        IdStock = Grossiste.Stocks.FirstOrDefault().Id,
                        PrixTotaleHt = detail.MontantHt,
                        PrixTotaleTTc = detail.MontantTTc,
                        Quantite = detail.Quantite,
                        Produit = produit,
                        Stock = Grossiste.Stocks.FirstOrDefault()

                    };
                    var index = bon.DetailsReceptions.ToList().FindIndex(w => w.IdProduit == item.IdProduit);
                    if (index >= 0)
                    {
                        var aux = model.DetailsBonReceptionModels.ElementAt(index).Quantite - item.Quantite;
                        await stockProduitService.Augmenter(aux, stockProduit.IdProduit, stockProduit.IdStock, stockProduit);


                    }
                    else
                    {
                        var x = item.Quantite;
                        await stockProduitService.Augmenter(x, stockProduit.IdProduit, stockProduit.IdStock, stockProduit);

                    }

                }
                entity.FournisseurId = model.FournisseurId;
                entity.DetailsReceptions = list;
                entity.PrixTotaleTTc = sumTTc;
                entity.PrixTotaleHt = sumHt;
                await bonDeReceptionFournisseurService.Update(entity.Id, entity);
            }
            else
            {
                return Ok(StatusCode(200));

            }

            return Ok(StatusCode(400));

        }
        [Authorize]
        [HttpPut("Confirmer")]
        public async Task<IActionResult> ConfirmerBonReception([FromForm]  int id)
        {
            var bon = await bonDeReceptionFournisseurService.GetById(id, "DetailsReceptions");
            bon.Confirmed = true;
            await bonDeReceptionFournisseurService.Update(bon.Id, bon);

            return Ok(StatusCode(200));
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> Details(int id)
        {
            var Entity = await bonDeReceptionFournisseurService.GetById(id, "");

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
