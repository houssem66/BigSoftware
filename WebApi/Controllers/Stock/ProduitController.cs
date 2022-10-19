using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProduitController(IProduitService _ProduitService, IWebHostEnvironment hostingEnvironment)
        {
            produitService = _ProduitService;
            this.hostingEnvironment = hostingEnvironment;
        }
        //[Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Produit>> PostClient([FromBody] ProduitModel model)
        {

            if (ModelState.IsValid)
            {



                var y = ((decimal)model.TVA);
                var x = model.PriceHT * (y / 100) + model.PriceHT;
                var entity = new Produit
                {
                    Barcode = model.Barcode,
                    Category = model.Category,
                    Description = model.Description,
                    TVA = model.TVA,
                    PriceHt = model.PriceHT,
                    PriceTTc = x,
                    ProductName = model.ProductName,
                    UnitOfMeasure = model.UnitOfMeasure,

                };
                try { await produitService.Ajout(entity); }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return Ok(StatusCode(400));
                }


                return CreatedAtAction("Details", new { id = entity.Id }, entity);
            }
            model.Message = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToString();



            return BadRequest(model.Message);
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
        public async Task<IActionResult> Update(int id, ProduitModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Message = ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToString();
                return BadRequest(model.Message);
            }
            var y = ((decimal)model.TVA);
            var x = model.PriceHT * (y / 100) + model.PriceHT;
            var entity = new Produit
            {
                Barcode = model.Barcode,
                Category = model.Category,
                Description = model.Description,
                TVA = model.TVA,
                PriceHt = model.PriceHT,
                PriceTTc = x,
                ProductName = model.ProductName,
                UnitOfMeasure = model.UnitOfMeasure,
            };
            try
            {
                await produitService.Update(model.Id, entity);

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
