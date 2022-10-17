using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
namespace Services.Implementation
{
    public class StockProduitService:IStockProduitService
    {
        private readonly IGenericRepository<StockProduit> genericRepository;

        public StockProduitService(BigSoftContext _bigSoftContext, IGenericRepository<StockProduit> _genericRepository)
        {
            BigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public BigSoftContext BigSoftContext { get; }

        public Task Ajout(StockProduit entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<StockProduit> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<StockProduit> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, StockProduit entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
