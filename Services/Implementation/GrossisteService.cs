using Data.Entities;
using Data.Models;
using Repository.Implementation;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Implementation
{
    public class GrossisteService : IGrossisteService
    {
        private readonly IGenericRepository<Grossiste> genericRepo;
        private readonly IGrossiteRepo grossisteRepo;

        public GrossisteService(IGenericRepository<Grossiste> _GenericRepo, IGrossiteRepo _GrossisteRepo)
        {
            genericRepo = _GenericRepo;
            grossisteRepo = _GrossisteRepo;
        }
      

        public Task Delete(string id)
        {
            return genericRepo.DeleteAsync(id);
        }

        public List<Grossiste> GetAll()
        {
            return genericRepo.GetAll().ToList();
        }

     
        public Task<Grossiste> GetById(string id)
        {
            return genericRepo.GetByIdAsync(id);
        }

      

        public Task<AuthModel> Login(TokenRequestModel model)
        {
            return grossisteRepo.GetTokenAsync(model);
        }

        public Task<AuthModel> RegisterAsync(RegisterModelGrossiste model)
        {
            return grossisteRepo.RegisterAsync(model);
        }

        public Task Update(string id,Grossiste entity)
        {
            return genericRepo.PutAsync(id, entity);
        }
    }
}
