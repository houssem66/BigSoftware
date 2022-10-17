using Data;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class FactureClientService : IFactureClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<FactureClient> genericRepository;

        public FactureClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<FactureClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(FactureClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<FactureClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<FactureClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, FactureClient entity)
        {
            return genericRepository.PutAsync(id,entity);
        }
    }
}
