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
            return genericRepo.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepo.DeleteAsync(id);
        }

        public List<Client> GetAll()
        {
            return genericRepo.GetAll().ToList();
        }

        public Task<Client> GetById(int id)
        {
            return genericRepo.GetByIdAsync(id);
        }

       

       

        public Task Update(int id, Client entity)
        {
            return genericRepo.PutAsync(id, entity);
        }
    }
}
