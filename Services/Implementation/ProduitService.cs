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
    public class ProduitService : IProduitService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Produit> genericRepository;

        public ProduitService(BigSoftContext _bigSoftContext, IGenericRepository<Produit> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
        public Task Ajout(Produit entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<Produit> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<Produit> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, Produit entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
