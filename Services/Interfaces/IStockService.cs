using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Interfaces
{
    public interface IStockService
    {
        public Task Update(int id, Stock entity);
        public Task<Stock> GetById(int id);
        public Task Delete(int id);
        public List<Stock> GetAll();
        public Task Ajout(Stock entity);
    }
}
