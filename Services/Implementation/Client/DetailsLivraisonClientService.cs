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
    public class DetailsLivraisonClientService:IDetailsLivraisonClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsLivraisonClient> genericRepository;

        public DetailsLivraisonClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<DetailsLivraisonClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsLivraisonClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsLivraisonClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsLivraisonClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsLivraisonClient entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
