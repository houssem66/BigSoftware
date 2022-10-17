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
    public class BonDeReceptionFournisseurService: IBonDeReceptionFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonDeReceptionFournisseur> genericRepository;

        public BonDeReceptionFournisseurService(BigSoftContext _bigSoftContext, IGenericRepository<BonDeReceptionFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public Task Ajout(BonDeReceptionFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<BonDeReceptionFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<BonDeReceptionFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, BonDeReceptionFournisseur entity)
        {
            return genericRepository.PutAsync(id,entity);
        }
    }
}
