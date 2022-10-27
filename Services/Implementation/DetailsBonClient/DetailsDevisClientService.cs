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
    public class DetailsDevisClientService:IDetailsDevisClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsDevis> genericRepository;

        public DetailsDevisClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<DetailsDevis> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsDevis entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsDevis> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsDevis> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsDevis entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
