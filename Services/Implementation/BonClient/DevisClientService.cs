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
    public class DevisClientService:IDevisClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Devis> genericRepository;

        public DevisClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<Devis> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            bigSoftContext = _bigSoftContext;
          
        }
        public Task Ajout(Devis entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<Devis> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<Devis> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, Devis entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
