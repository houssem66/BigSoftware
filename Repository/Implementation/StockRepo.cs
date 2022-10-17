using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task PutAsync(int id, Stock entity)
        {
            var stock = await bigSoftContext.Stocks.SingleAsync(user => user.Id == id);
            stock.StoreName = entity.StoreName;
            try
            {
                bigSoftContext.Stocks.Update(stock);
                await bigSoftContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
