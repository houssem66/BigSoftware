using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStockProduitRepo : IRepositoryBase<StockProduit>
    {
        public void Augmenter(decimal? aug, StockProduit entity);
        public void Diminuer( StockProduit entity);

    }
}
