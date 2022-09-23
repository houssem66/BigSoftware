using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicesitory.Interfaces
{
    public interface IStockStockProduitService
    {
        public Task Update(int id, StockProduit entity);
        public Task<StockProduit> GetById(int id);
        public Task Delete(int id);
        public List<StockProduit> GetAll();
        public Task Ajout(StockProduit entity);
    }
}
