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
    public class BonDeCommandeFournisseurService:IBonDeCommandeFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonDeCommandeFournisseur> genericRepository;

        public BonDeCommandeFournisseurService(BigSoftContext _bigSoftContext, IGenericRepository<BonDeCommandeFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public Task Ajout(BonDeCommandeFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<BonDeCommandeFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<BonDeCommandeFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, BonDeCommandeFournisseur entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
