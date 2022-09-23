using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class StockRepo:IStockRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Stock> genericRepository;

        public StockRepo(BigSoftContext _bigSoftContext, IGenericRepository<Stock> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public Task Ajout(Stock entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
