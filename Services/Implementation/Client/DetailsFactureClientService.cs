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
    public class DetailsFactureClientService:IDetailsFactureClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsFactureClient> genericRepository;

        public DetailsFactureClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<DetailsFactureClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsFactureClient entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsFactureClient> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsFactureClient> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsFactureClient entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
