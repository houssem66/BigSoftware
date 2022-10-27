using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStockProduitService
    {
        public  Task Augmenter(decimal? augmentation,int idProduit, int idStock, StockProduit entity);
        public  Task Diminuer(int idProduit, int idStock, StockProduit entity);

    }
}
