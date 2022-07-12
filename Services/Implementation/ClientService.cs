using Data.Entities;
using Repository.Implementation;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> genericRepo;
        private readonly IGrossiteRepo ClientRepo;

        public ClientService(IGenericRepository<Client> _GenericRepo, IGrossiteRepo _ClientRepo)
        {
            genericRepo = _GenericRepo;
            ClientRepo = _ClientRepo;
        }
        public Task Ajout(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
