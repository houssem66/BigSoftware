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
                    entity.PrixTotaleTTc = sumTTc;
                    entity.PrixTotaleHt = sumHt;
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
        [HttpGet("Get")]
        public async Task<ActionResult<BonDeCommandeFournisseur>> Details([FromQuery] QueryParametersInt parameters)
        {
            var list = repository.BonDeCommandeFournisseurRepo.FindAll();
            var Entity = await repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.Id == parameters.Id).FirstOrDefaultAsync();

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
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.Id == id, includeProperties: "DetailsCommandes").FirstOrDefaultAsync();
                    if (entity == null)
                    {
                        return Ok(StatusCode(400));

                    }
                    else
                    {
                        try
                        {
                            mapper.Map(model, entity);
                            var list = new List<DetailsCommandeFournisseur>();
                            Decimal? sumTTc = 0;
                            Decimal? sumHt = 0;
                            foreach (var item in model.DetailsBonCommandes)
                            {
                                var produit = await repository.ProduitRepo.FindById(item.IdProduit);
                                var detail = new DetailsCommandeFournisseur
                                {
                                    IdProduit = produit.Id,
                                    IdBonCommande = id,
                                    MontantHt = produit.PriceHt * item.Quantite,
                                    MontantTTc = produit.PriceTTc * item.Quantite,
                                    Quantite = item.Quantite,
                                    Produit = produit
                                };
                                sumTTc += detail.MontantTTc;
                                sumHt += detail.MontantHt;
                                list.Add(detail);
                            }
                            entity.DetailsCommandes = list;
                            entity.PrixTotaleTTc = sumTTc;
                            entity.PrixTotaleHt = sumHt;
                            repository.BonDeCommandeFournisseurRepo.Update(entity);
                            await repository.SaveAsync();
                            return Ok(StatusCode(200));
                        }
                        catch (Exception e)
                        {
                            throw new NotImplementedException();
                        }

                    }
                }
                catch (Exception e)
                {
                    return Ok(StatusCode(400));
                }

          

            }
            else
            {
                return Ok(StatusCode(400));

            }


        }
        [Authorize]
        [HttpGet()]
        public IQueryable GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }

            return (repository.BonDeCommandeFournisseurRepo.FindByCondition(x => x.GrossisteId == parameters.Id, includeProperties: parameters.include));
        }
    }
}

