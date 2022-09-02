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

namespace WebApi.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService ClientService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;

        public ClientController(IClientService _ClientService, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService)
        {

            ClientService = _ClientService;
           _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client model)
        {
            {if (ModelState.IsValid) { 
                try { await ClientService.Ajout(model); }

                catch (Exception ex) { 
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }


                return CreatedAtAction("Details", new { id = model.Id }, model);
                }
            }

            return Ok(StatusCode(400));
        }
      
        [Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (ClientService.GetAll().AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await ClientService.Delete(id);
               
                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, Client entity)
        {
            try
            {
                await ClientService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

       
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Client>> Details(int id)
        {
            var Entity = await ClientService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
     
    }
}
