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
    public class DetailsBonSortieClientService:IDetailsBonSortieClientService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsBonSortie> genericRepository;

        public DetailsBonSortieClientService(Data.BigSoftContext _bigSoftContext, IGenericRepository<DetailsBonSortie> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(DetailsBonSortie entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<DetailsBonSortie> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<DetailsBonSortie> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, DetailsBonSortie entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
