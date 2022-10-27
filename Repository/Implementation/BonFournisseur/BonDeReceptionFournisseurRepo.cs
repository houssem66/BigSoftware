using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BonDeReceptionFournisseurRepo : IBonDeReceptionFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonDeReceptionFournisseur> genericRepository;

        public BonDeReceptionFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<BonDeReceptionFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public IEnumerable<BonDeReceptionFournisseur> GetAll(string id)
        {
            return bigSoftContext.BonDeRéceptionFournisseurs.Where(e => e.GrossisteId == id)
                .Include(x => x.DetailsReceptions)
                .ThenInclude(x => x.Produit)
                .Include(x => x.Fournisseur)
                .ThenInclude(x => x.Grossiste)
                .Include(x => x.FactureFournisseur)
                .ThenInclude(x => x.DetailsFactures);
        }

        public async Task<BonDeReceptionFournisseur> GetById(int id, string include)
        {
            var entity = await bigSoftContext.BonDeRéceptionFournisseurs
                .Include(x => x.Grossiste)
                .ThenInclude(x => x.Stocks)
                .Include(x => x.DetailsReceptions)
                .ThenInclude(x => x.Produit)
                .Include(x => x.FactureFournisseur)
                .ThenInclude(x => x.DetailsFactures)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<BonDeReceptionFournisseur> GetById(int id)
        {
            var entity = await bigSoftContext.BonDeRéceptionFournisseurs.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task PutAsync(int id, BonDeReceptionFournisseur entity)
        {
            var bon = await bigSoftContext.BonDeRéceptionFournisseurs.SingleOrDefaultAsync(x => x.Id == id);
            bon.Date = entity.Date;
            bon.DetailsReceptions = entity.DetailsReceptions;
            bon.PrixTotaleHt = entity.PrixTotaleHt;
            bon.PrixTotaleTTc = entity.PrixTotaleTTc;
            bon.FournisseurId = entity.FournisseurId;



            try
            {
                bigSoftContext.BonDeRéceptionFournisseurs.Update(bon);
                await bigSoftContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
