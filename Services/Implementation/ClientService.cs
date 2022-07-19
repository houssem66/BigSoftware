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
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> genericRepo;
        private readonly IClientRepo ClientRepo;

        public ClientService(IGenericRepository<Client> _GenericRepo, IClientRepo _ClientRepo)
        {
            genericRepo = _GenericRepo;
            ClientRepo = _ClientRepo;
        }
        public Task Ajout(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            return genericRepo.DeleteAsync(id);
        }

        public List<Client> GetAll()
        {
            return genericRepo.GetAll().ToList();
        }

        public Task<Client> GetById(string id)
        {
            return genericRepo.GetByIdAsync(id);
        }

        public Task<AuthModel> Login(TokenRequestModel model)
        {
            return ClientRepo.GetTokenAsync(model);
        }

        public Task<AuthModel> RegisterAsync(RegisterModelClient model)
        {
            return ClientRepo.RegisterAsync(model);
        }

        public Task Update(string id, Client entity)
        {
            return genericRepo.PutAsync(id, entity);
        }
    }
}
