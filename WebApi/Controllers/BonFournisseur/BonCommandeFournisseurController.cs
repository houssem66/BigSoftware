using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.BonFournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonCommandeFournisseurController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public BonCommandeFournisseurController(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //  [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonDeCommandeFournisseur>> PostBonDeCommandeFournisseur([FromBody] BonCommandeFModel model)
        {
            {

                if (ModelState.IsValid)
                {
                    var entity = mapper.Map<BonDeCommandeFournisseur>(model);
                    try
                    {

                        repository.BonDeCommandeFournisseurRepo.Create(entity);
                        await repository.SaveAsync();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }
                    var list = new List<DetailsCommandeFournisseur>();
                    Decimal? sumTTc = 0;
                    Decimal? sumHt = 0;
                    foreach (var item in model.DetailsBonCommandes)
                    {
                        var produit = await repository.ProduitRepo.FindById(item.IdProduit);

                        var detail = new DetailsCommandeFournisseur
                        {
                            IdProduit = produit.Id,
                            IdBonCommande = entity.Id,
                            MontantHt = produit.PriceHt * item.Quantite,
                            MontantTTc = produit.PriceTTc * item.Quantite,
                            Quantite = item.Quantite,
                        };
                        sumTTc += detail.MontantTTc;
                        sumHt += detail.MontantHt;
                        list.Add(detail);
                    }
                    entity.DetailsCommandes = list;
                    //entity.PrixTotaleTTc = sumTTc;
                    //entity.PrixTotaleHt = sumHt;
                    try
                    {
                        repository.BonDeCommandeFournisseurRepo.Update(entity);
                        await repository.SaveAsync();
                        return CreatedAtAction("Details", new { id = entity.Id }, entity);
                    }
                    catch (Exception e)
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            return Ok(StatusCode(400));
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<BonDeCommandeFournisseur>> Details(int id)
        {
            var Entity = await repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "Fournisseur.Grossiste,DetailsCommandes.Produit").FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await repository.BonDeCommandeFournisseurRepo.FindById(id);
            try
            {
                repository.BonDeCommandeFournisseurRepo.Delete(entity);
                await repository.SaveAsync();
                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] BonCommandeFModel model)
        {
           try
            {if (model == null)
                {
                    return BadRequest("Model is empty");
                }
            if (!ModelState.IsValid)
                {   return BadRequest("Invalid model object"); }
                var bon =await repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsCommandes").FirstOrDefaultAsync();
                if (bon == null) { return NotFound(); }
                mapper.Map(model, bon);
                var listjoin = model.DetailsBonCommandes.GroupJoin(
                             bon.DetailsCommandes,
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
                var listExept = bon.DetailsCommandes.Select(x => x.IdProduit).Except(model.DetailsBonCommandes.Select(x => x.IdProduit)).ToList();
                bon.DetailsCommandes = bon.DetailsCommandes.Where(x => (!listExept.Contains(x.IdProduit))).ToList();
                foreach (var item in listjoin)
                {
                    if (item.details.ToList().Count < 1)
                    {
                        var detail = new DetailsCommandeFournisseur
                        {
                            IdProduit = item.idProduit,
                            IdBonCommande = id,
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

                repository.BonDeCommandeFournisseurRepo.Update(bon);
                await repository.SaveAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error with Exception:" + e.Message);
            }


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
                return Ok(repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));

            }
            return Ok(repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id && x.FournisseurId == parameters.iDC, includeProperties: parameters.include));
        }
    }
}

