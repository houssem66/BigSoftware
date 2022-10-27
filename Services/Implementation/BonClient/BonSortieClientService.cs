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
    public class BonSortieClientService:IBonSortieClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonSortie> genericRepository;

        public BonSortieClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<BonSortie> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(BonSortie entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<BonSortie> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<BonSortie> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, BonSortie entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
