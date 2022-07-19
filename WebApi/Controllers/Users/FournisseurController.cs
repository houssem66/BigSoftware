using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private readonly IFournisseurService fournisseurService;

        public FournisseurController(IFournisseurService _FournisseurService)
        {
            fournisseurService = _FournisseurService;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModelFournisseur model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await fournisseurService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await fournisseurService.Login(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
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
