﻿using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.BonClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonCommandeClientController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositoryWrapper repository;

        public BonCommandeClientController(IMapper mapper, IRepositoryWrapper repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonCommandeClient>> PostBonDeReceptionFournisseur([FromBody] BonCommandeCModel model)
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

                var entity = mapper.Map<BonCommandeClient>(model);
                entity.DetailsCommandes = new Collection<DetailsCommandeClient>();
             //   //entity.PrixTotaleTTc = 0;
               // //entity.PrixTotaleHt = 0;
                foreach (var item in model.DetailsBonCommandes)
                {

                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    if (produit != null)
                    {
                        var detail = new DetailsCommandeClient
                        {
                            IdProduit = produit.Id,
                            IdCommande = entity.Id,
                            MontantHt = produit.PriceHt * item.Quantite,
                            MontantTTc = produit.PriceTTc * item.Quantite,
                            Quantite = item.Quantite,
                        };
                        entity.DetailsCommandes.Add(detail);
                       // //entity.PrixTotaleHt += produit.PriceHt * item.Quantite;
                       // //entity.PrixTotaleTTc += produit.PriceTTc * item.Quantite;
                    }
                }

                repository.CommandeClientRepo.Create(entity);
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
        public async Task<ActionResult<BonCommandeClient>> Details(int id)
        {
            var Entity = await repository.CommandeClientRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "DetailsCommandes.Produit,Client,Grossiste"
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
         
            if (parameters.Id == null)
            {
                return StatusCode(500, "Empty");
                
            }
            if (parameters.iDC <1)
            {
                return Ok(repository.CommandeClientRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));

            }
            return Ok(repository.CommandeClientRepo.FindByCondition(x => x.GrossisteId == parameters.Id && x.ClientId == parameters.iDC, includeProperties: parameters.include));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.CommandeClientRepo.FindById(id);
                if (bon == null)
                {
                    return NotFound();
                }
                repository.CommandeClientRepo.Delete(bon);
                await repository.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [Authorize]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BonCommandeCModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest(" model object is null");
                }
                var bon = await repository.CommandeClientRepo
                    .FindByCondition(x => x.Id == id,
                   includeProperties: "DetailsCommandes.Produit,Client,Grossiste").FirstOrDefaultAsync();
                if (bon is null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                mapper.Map(model, bon);
                var listjoin = model.DetailsBonCommandes.GroupJoin(
                               bon.DetailsCommandes,
                               detail => detail.IdProduit,
                               bon => bon.IdProduit,
                               (detail, y) => new
                               {
                                   idProduit = detail.IdProduit,
                                   idBon = detail.IdCommande,
                                   quantite = detail?.Quantite,
                                   produit = repository.ProduitRepo.GetById(detail.IdProduit),
                                   details = y,
                               }
                               );
                var listExept = bon.DetailsCommandes.Select(x => x.IdProduit).Except(model.DetailsBonCommandes.Select(x => x.IdProduit)).ToList();
                bon.DetailsCommandes = bon.DetailsCommandes.Where(x => (!listExept.Contains(x.IdProduit))).ToList();
                foreach (var item in listjoin)
                {
                    if (item.details.ToList().Count <1 )
                    {
                        var detail = new DetailsCommandeClient
                        {
                            IdProduit = item.idProduit,
                            IdCommande = id,
                            MontantHt = item.produit.PriceHt * item.quantite,
                            MontantTTc = item.produit.PriceTTc * item.quantite,
                            Quantite = item.quantite,

                        };
                        bon.DetailsCommandes.Add(detail);
                    }
                    else
                    {
                        item.details.FirstOrDefault().MontantHt = item.produit.PriceHt * item.quantite;
                        item.details.FirstOrDefault().MontantTTc = item.produit.PriceTTc * item.quantite;
                        item.details.FirstOrDefault().Quantite = item.quantite;
                    }
                  
                }

                repository.CommandeClientRepo.Update(bon);
                await repository.SaveAsync();


                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }



        }
    }
}
