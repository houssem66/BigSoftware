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
    public class DetailsFactureFournisseurService:IDetailsFactureFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsFactureFournisseur> genericRepository;

        public DetailsFactureFournisseurService(BigSoftContext _bigSoftContext, IGenericRepository<DetailsFactureFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsFactureFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsFactureFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsFactureFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsFactureFournisseur entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
