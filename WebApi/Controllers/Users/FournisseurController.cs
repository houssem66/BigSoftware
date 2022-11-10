using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public FournisseurController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Fournisseur>> PostFournisseur([FromBody] FournisseurModel model)
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
                var entity = new Fournisseur
                {
                    Adresse = model.Adresse,
                    Gouvernorats = model.Gouvernorats,
                    Email = model.Email,
                    IdGrossiste = model.IdGrossiste,
                    CodePostale = model.CodePostale,
                    Identifiant_fiscale = model.Identifiant_fiscale,
                    NomPersAContact = model.NomPersAContact,
                    NumMobile = model.NumMobile,
                    PhoneBureau = model.PhoneBureau,
                    PrenomPersAContact = model.PrenomPersAContact,
                    RaisonSocial = model.RaisonSocial,
                    SiteWeb = model.SiteWeb,
                    Civility=model.Civility,
                    FormeJuridique=model.FormeJuridique,
                    
                };


                repository.FournisseurRepo.Create(entity);
                await repository.SaveAsync();
                return CreatedAtAction("Details", new { id = entity.Id }, model);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Interna server error" + ex.Message);
            }

        }
        [HttpPost("token")]

        [Authorize]
        [HttpGet("{id}")]
        public IQueryable GetAll(string id)
        {


            return (repository.FournisseurRepo.FindByCondition(x => x.IdGrossiste == id).AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest("id is null");
                var fournisseur = await repository.FournisseurRepo.FindById(id);
                if (fournisseur == null) return BadRequest("fournisseur is empty");

                repository.FournisseurRepo.Delete(fournisseur);
                await repository.SaveAsync();
                return Ok(StatusCode(200));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, Fournisseur entity)
        {
            try
            {
                if (entity is null)
                {
                    return BadRequest(" model object is null");
                }
              
                 repository.FournisseurRepo.Update( entity);
                await repository.SaveAsync();
                return Ok(StatusCode(200));
            }
            catch (Exception ex)
            {

                return BadRequest(ModelState);
            }


        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Fournisseur>> Details(int id)
        {
            var Entity = await repository.FournisseurRepo.FindById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }


    }
}
