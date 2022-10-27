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
    public class BonLivraisonClientService:IBonLivraisonClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonLivraisonClient> genericRepository;

        public BonLivraisonClientService(BigSoftContext _bigSoftContext, IGenericRepository<BonLivraisonClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(BonLivraisonClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<BonLivraisonClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<BonLivraisonClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, BonLivraisonClient entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
