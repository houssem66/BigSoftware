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
    public class DetailsCommandeClientService:IDetailsCommandeClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsCommandeClient> genericRepository;

        public DetailsCommandeClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<DetailsCommandeClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsCommandeClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsCommandeClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsCommandeClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsCommandeClient entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
