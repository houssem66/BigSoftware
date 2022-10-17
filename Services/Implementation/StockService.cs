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
    public class StockService:IStockService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Stock> genericRepository;
        private readonly IStockRepo stockRepo;

        public StockService(BigSoftContext _bigSoftContext, IGenericRepository<Stock> _genericRepository,IStockRepo _stockRepo)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
            stockRepo = _stockRepo;
        }

        public Task Ajout(Stock entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<Stock> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<Stock> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, Stock entity)
        {
            return stockRepo.PutAsync(id, entity);
        }
    }
}
