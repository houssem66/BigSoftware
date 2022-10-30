using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class FactureFournisseurController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public FactureFournisseurController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [Authorize]
        [HttpGet()]
            public IActionResult GetAll([FromQuery] QueryParametersString parameters)
        {
            if (parameters.include == null)
            {
                parameters.include = "";
            }
            if (parameters.Id is null )
            {
                return StatusCode(500, "Empty");

            }
            return Ok(repository.FactureFournisseurRepo.FindByCondition(x => x.BonDeReceptionFournisseur.GrossisteId == parameters.Id, includeProperties: parameters.include));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bon = await repository.BonDeReceptionFournisseurRepo.FindById(id);
                if (bon == null)
                {
                    return NotFound();
                }
                else
                {
                    repository.BonDeReceptionFournisseurRepo.Delete(bon);
                    await repository.SaveAsync();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
