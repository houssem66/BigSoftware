using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Services.Implementation;
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

        public BonReceptionController(IBonDeReceptionFournisseurService _BonDeReceptionFournisseurService,IProduitService _ProduitService, IDetailsBonDeReceptionFournisseurService _DetailsBonReceptionService)
        {
            bonDeReceptionFournisseurService = _BonDeReceptionFournisseurService;
            produitService = _ProduitService;
            detailsBonReceptionService = _DetailsBonReceptionService;
        }
      //  [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> PostBonDeReceptionFournisseur([FromBody] BonReceptionModel model)
        {
            {
                var entity = new BonDeReceptionFournisseur {
                    Date=model.Date,
                    PrixTotaleHt=model.PrixTotaleHt,
                    PrixTotaleTTc=model.PrixTotaleTTc,
                    FournisseurId=model.FournisseurId,
                    GrossisteId=model.GrossisteId
                    

                };
                if (ModelState.IsValid)
                {
                    try { await bonDeReceptionFournisseurService.Ajout(entity);
                    
                    
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }
                    var list = new List<DetailsReceptionFournisseur>();
                    Decimal? sumTTc = 0;
                    Decimal? sumHt = 0;
                    foreach(var item in model.DetailsBonReceptionModels)
                    { var produit = await produitService.GetById(item.IdProduit);
                        var detail = new DetailsReceptionFournisseur
                        {
                            IdProduit = produit.Id,
                            IdBonReception = entity.Id,
                            MontantHt = produit.PriceHt * item.Quantite,
                            MontantTTc=produit.PriceTTc*item.Quantite,
                            Quantite=item.Quantite,
                            Produit=produit
                            


                        };
                        sumTTc += detail.MontantTTc;
                        sumHt += detail.MontantHt;
                        list.Add(detail);
                       
                    }
                    entity.DetailsReceptions = list;
                    entity.PrixTotaleTTc = sumTTc;
                    entity.PrixTotaleHt = sumHt;
                    await   bonDeReceptionFournisseurService.Update(entity.Id,entity);
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
        public async Task<IActionResult> Update(int id, BonDeReceptionFournisseur entity)
        {
            try
            {
                await bonDeReceptionFournisseurService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }


        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> Details(int id)
        {
            var Entity = await bonDeReceptionFournisseurService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
