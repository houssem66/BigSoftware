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
    public class DetailsBonReceptionService:IDetailsBonDeReceptionFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsReceptionFournisseur> genericRepository;

        public DetailsBonReceptionService(BigSoftContext _bigSoftContext, IGenericRepository<DetailsReceptionFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsReceptionFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsReceptionFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsReceptionFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsReceptionFournisseur entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
