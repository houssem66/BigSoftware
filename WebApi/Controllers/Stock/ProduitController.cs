using Data.Entities;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService produitService;

        public ProduitController(IProduitService _ProduitService)
        {
            produitService = _ProduitService;
        }
//[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Produit>> PostClient([FromBody] Produit model)
        {
            {
                if (ModelState.IsValid)
                {
                    try { await produitService.Ajout(model); }

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
        [HttpGet]
        public IQueryable GetAll()
        {


            return (produitService.GetAll().AsQueryable());
        }
//[Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await produitService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
//[Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, Produit entity)
        {
            try
            {
                await produitService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }


        }
//[Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Produit>> Details(int id)
        {
            var Entity = await produitService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
    }
}
