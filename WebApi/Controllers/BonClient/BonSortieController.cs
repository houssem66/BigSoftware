using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.BonClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonSortieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositoryWrapper repository;

        public BonSortieController(IMapper mapper, IRepositoryWrapper repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonSortie>> PostBonDeReceptionFournisseur([FromBody] BonSortieViewModel model)
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

                var entity = mapper.Map<BonSortie>(model);
                entity.DetailsBonSorties = new Collection<DetailsBonSortie>();
                entity.PrixTotaleTTc = 0;
                entity.PrixTotaleHt = 0;
                foreach (var item in model.DetailsBonSortieModels)
                {

                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    if (produit != null)
                    {
                        var detail = new DetailsBonSortie
                        {
                            IdProduit = produit.Id,
                            IdBonSortie = entity.Id,
                            MontantHt = produit.PriceHt * item.Quantite,
                            MontantTTc = produit.PriceTTc * item.Quantite,
                            Quantite = item.Quantite,
                        };
                        entity.DetailsBonSorties.Add(detail);
                        entity.PrixTotaleHt += produit.PriceHt * item.Quantite;
                        entity.PrixTotaleTTc += produit.PriceTTc * item.Quantite;
                    }
                }

                repository.BonSortieClientRepo.Create(entity);
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
        public async Task<ActionResult<BonSortie>> Details(int id)
        {
            var Entity = await repository.BonSortieClientRepo.FindByCondition
                (x =>
                x.Id == id, includeProperties: "DetailsBonSorties.Produit,Client,Grossiste"
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
                return Ok(repository.BonSortieClientRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));
            }
            return StatusCode(500, "Empty");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.BonSortieClientRepo.FindById(id);
                if (bon == null)
                {
                    return NotFound();
                }
                repository.BonSortieClientRepo.Delete(bon);
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
        public async Task<IActionResult> Update(int id, [FromBody] BonSortieViewModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest(" model object is null");
                }
                var bon = await repository.BonSortieClientRepo
                    .FindByCondition(x => x.Id == id,
                   includeProperties: "DetailsBonSorties.Produit,Client,Grossiste").FirstOrDefaultAsync();
                if (bon is null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                mapper.Map(model, bon);
                var list = new List<DetailsBonSortie>();
                bon.PrixTotaleTTc = 0;
                bon.PrixTotaleHt = 0;
                foreach (var item in model.DetailsBonSortieModels)
                {
                    var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                    var detail = new DetailsBonSortie
                    {
                        IdProduit = produit.Id,
                        IdBonSortie = id,
                        MontantHt = produit.PriceHt * item.Quantite,
                        MontantTTc = produit.PriceTTc * item.Quantite,
                        Quantite = item.Quantite,
                        Produit = produit
                    };
                    bon.PrixTotaleTTc += detail.MontantTTc;
                    bon.PrixTotaleHt += detail.MontantHt;
                    list.Add(detail);
                }
                bon.DetailsBonSorties = list;

                repository.BonSortieClientRepo.Update(bon);
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
