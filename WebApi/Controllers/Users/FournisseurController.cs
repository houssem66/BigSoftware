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

        public FournisseurController(IFournisseurService _FournisseurService, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService)
        {
            fournisseurService = _FournisseurService;
           _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
        }
        [AllowAnonymous]
        [HttpPost("Post")]
        public async Task<ActionResult<Fournisseur>> PostFournisseur([FromBody] Fournisseur model)
        {try { await fournisseurService.Ajout(model); }
           
            catch(Exception ex) { Console.WriteLine(ex); }
            return CreatedAtAction("Details", new { id = model.Id }, model);
        }
        [HttpPost("token")]
       
        [Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (fournisseurService.GetAll().AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await fournisseurService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(string id, Fournisseur entity)
        {
            try
            {
                await fournisseurService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }
          

        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Fournisseur>> Details(string id)
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
