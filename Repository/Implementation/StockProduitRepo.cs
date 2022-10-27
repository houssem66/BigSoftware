using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class StockProduitRepo : IStockProduitRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<StockProduit> genericRepository;

        public StockProduitRepo(BigSoftContext _bigSoftContext, IGenericRepository<StockProduit> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public async Task Augmenter(decimal? aug,int idProduit, int idStock, StockProduit entity)
        
        {var bon = new StockProduit();
            try {
                 bon = await bigSoftContext.StockProduits.SingleOrDefaultAsync(x => x.IdProduit == idProduit && x.IdStock == idStock);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            if (bon != null)
            {
                try
                {
                    bon.PrixTotaleHt += entity.PrixTotaleHt;
                    bon.PrixTotaleTTc += entity.PrixTotaleTTc;
                    bon.Quantite += aug;
                    bigSoftContext.StockProduits.Update(bon);
                    await bigSoftContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }

            }
            else
            {
                try
                {
                    entity.Quantite = aug;
                    await genericRepository.InsertAsync(entity);
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }

            }
        }


        public async Task Diminuer(int idProduit, int idStock, StockProduit entity)
        {
            var bon = new StockProduit();
            try
            {
                bon = await bigSoftContext.StockProduits.SingleOrDefaultAsync(x => x.IdProduit == idProduit && x.IdStock == idStock);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            if (bon != null)
            {
                try
                {
                    bon.PrixTotaleHt -= entity.PrixTotaleHt;
                    bon.PrixTotaleTTc -= entity.PrixTotaleTTc;
                    bon.Quantite -= entity.Quantite;
                    bigSoftContext.StockProduits.Update(bon);
                    await bigSoftContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }

            }
        }
    }
}
