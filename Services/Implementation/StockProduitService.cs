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
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<StockProduit> genericRepository;
        private readonly IStockProduitRepo stockProduitRepo;

        public StockProduitService(BigSoftContext _bigSoftContext, IGenericRepository<StockProduit> _genericRepository,IStockProduitRepo _StockProduitRepo)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
            stockProduitRepo = _StockProduitRepo;
        }

        public Task Augmenter(decimal? aug,int idProduit, int idStock, StockProduit entity)
        {
            return stockProduitRepo.Augmenter(aug,idProduit,idStock,entity);
        }

        public Task Diminuer(int idProduit, int idStock, StockProduit entity)
        {
            return stockProduitRepo.Diminuer(idProduit, idStock, entity);
        }
    }
}
