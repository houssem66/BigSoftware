using Data;
using Data.Entities;
using Repository.Interfaces;
using System;

namespace Repository.Implementation
{
    public class StockProduitRepo : RepositoryBase<StockProduit>, IStockProduitRepo
    {
        public StockProduitRepo(BigSoftContext _bigSoftContext) : base(_bigSoftContext)
        {
        }

        public void Augmenter(decimal? aug, StockProduit entity)
        {
            if (entity != null)
            {
                entity.Quantite += aug;
                Update(entity);
            }
        }

  

        public void Diminuer(StockProduit entity)
        {

            try
            {


                Update(entity);

            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

        }
    }
}


