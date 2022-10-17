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
    public class DetailsBonCommandService:IDetailsBonCommandeFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsCommandeFournisseur> genericRepository;

        public DetailsBonCommandService(BigSoftContext _bigSoftContext, IGenericRepository<DetailsCommandeFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsCommandeFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsCommandeFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsCommandeFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsCommandeFournisseur entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
