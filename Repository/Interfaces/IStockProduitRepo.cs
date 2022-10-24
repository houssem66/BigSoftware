using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStockProduitRepo
    {
        public Task Augmenter(int idProduit, int idStock, StockProduit entity);
        public Task Diminuer(int idProduit, int idStock, StockProduit entity);

    }
}
