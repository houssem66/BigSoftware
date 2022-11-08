using AutoMapper;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;
        private readonly IGrossisteService grossisteService;
        private readonly IMapper mapper;

        public ClientController(IRepositoryWrapper repository, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService, IGrossisteService grossisteService, IMapper mapper)
        {

            this.repository = repository;
            _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
            this.grossisteService = grossisteService;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost("Post")]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client model)
        {
            {
                if (ModelState.IsValid)
                {
                    //var grossiste = await grossisteService.GetById(model.IdGrossiste);
                    //model.Grossiste = grossiste;
                    try
                    {
                        repository.ClientRepo.Create(model);
                        await repository.SaveAsync();
                    }

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

        [Authorize]
        [HttpGet("{id}")]
        public IQueryable GetAll(string id)
        {


            return (repository.ClientRepo.FindByCondition(x => x.IdGrossiste == id).AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await repository.ClientRepo.FindById(id);
            if (entity != null)
            {
                try
                {
                    repository.ClientRepo.Delete(entity);
                    await repository.SaveAsync();

                    return Ok(StatusCode(200));
                }
                catch (Exception)
                {

                    return Ok(StatusCode(400));
                }
            }

            return Ok(StatusCode(400));
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientViewModel model)
        {
            var client = await repository.ClientRepo.FindById(id);
            if (client != null)
            {       
                try
                {
                    mapper.Map(model, client);
                    repository.ClientRepo.Update(client);
                    await repository.SaveAsync();
                    return Ok(StatusCode(200));
                }
                catch (Exception e)
                {

                    return Ok(StatusCode(400));
                }
            }

            return Ok(StatusCode(400));

        }
        [Authorize]
        [HttpGet("Details")]
        public async Task<ActionResult<Client>> Details([FromQuery] QueryParametersInt parameters)
        {
            var Entity = await  repository.ClientRepo.FindByCondition(x=>x.Id==parameters.Id, includeProperties:parameters.include).FirstOrDefaultAsync();

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }

    }
}
public class QueryParametersInt
{
    public int Id { get; set; }
    public string include { get; set; }
}public class QueryParametersString
{
    public string Id { get; set; }
    public string include { get; set; }
    public int iDC { get; set; }
}

