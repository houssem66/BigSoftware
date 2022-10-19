using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public BonReceptionController(IBonDeReceptionFournisseurService _BonDeReceptionFournisseurService)
        {
            bonDeReceptionFournisseurService = _BonDeReceptionFournisseurService;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<BonDeReceptionFournisseur>> PostBonDeReceptionFournisseur([FromBody] BonDeReceptionFournisseur model)
        {
            {
                if (ModelState.IsValid)
                {
                    try { await bonDeReceptionFournisseurService.Ajout(model); }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return Ok(StatusCode(400));
                    }


                    return CreatedAtAction("Details", new { id = model.Id }, model);
                }
            }

            return Ok(StatusCode(400));
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public IQueryable GetAll(string id)
        //{


        //    return (bonDeReceptionFournisseurService.GetAll(id).AsQueryable());
        //}
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
