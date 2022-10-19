using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private readonly IFournisseurService fournisseurService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;

        public FournisseurController(IFournisseurService _FournisseurService)
        {
            fournisseurService = _FournisseurService;
           
          
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Fournisseur>> PostFournisseur([FromBody] FournisseurModel model)
        {
            var entity = new Fournisseur
            {
                Adresse = model.Adresse,
                Gouvernorats = model.Gouvernorats,
                Email = model.Email,
                IdGrossiste = model.IdGrossiste,
                CodePostale = model.CodePostale,
                Identifiant_fiscale = model.Identifiant_fiscale,
                NomPersAContact = model.NomPersAContact,
                Numbureau = model.Numbureau,
                NumFax = model.NumFax,
                PrenomPersAContact = model.PrenomPersAContact,
                RaisonSocial = model.RaisonSocial,
                SiteWeb = model.SiteWeb
            };
            try {
                
                await fournisseurService.Ajout(entity); }
           
            catch(Exception ex) { Console.WriteLine(ex); }
            return CreatedAtAction("Details", new { id = entity.Id }, model);
        }
        [HttpPost("token")]
       
        [Authorize]
        [HttpGet("{id}")]
        public IQueryable GetAll(string id)
        {


            return (fournisseurService.GetAll(id).AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await fournisseurService.Delete(id);

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
                await fournisseurService.Update(id, entity);

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
            var Entity = await fournisseurService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
       
        
    }
}
