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
    public class StockProduitRepo:IStockProduitRepo
    {
        private readonly IGenericRepository<StockProduit> genericRepository;

        public StockProduitRepo(BigSoftContext _bigSoftContext, IGenericRepository<StockProduit> _genericRepository)
        {
            BigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public BigSoftContext BigSoftContext { get; }
    }
}
