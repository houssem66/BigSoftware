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
    public class ProduitRepo:IProduitRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Produit> genericRepository;

        public ProduitRepo(BigSoftContext _bigSoftContext, IGenericRepository<Produit> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

      
        public async Task PutAsync(int id, Produit entity)
        {

            var produit = await bigSoftContext.Produits.SingleAsync(user => user.Id == id);
            produit.Barcode = entity.Barcode;
            produit.Category = entity.Category;
            produit.Description = entity.Description;
            produit.TVA = entity.TVA;
            produit.PriceHt = entity.PriceHt;
            produit.PriceTTc = entity.PriceTTc;
            produit.ProductName = entity.ProductName;
            produit.UnitOfMeasure = entity.UnitOfMeasure;
            try
            {
                bigSoftContext.Produits.Update(produit);
                await bigSoftContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
