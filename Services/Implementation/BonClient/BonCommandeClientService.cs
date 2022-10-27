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
    public class BonCommandeClientService:IBonCommandeClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonCommandeClient> genericRepository;

        public BonCommandeClientService(BigSoftContext _bigSoftContext, IGenericRepository<BonCommandeClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(BonCommandeClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<BonCommandeClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<BonCommandeClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, BonCommandeClient entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
