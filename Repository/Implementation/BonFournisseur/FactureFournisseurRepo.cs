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
    public class FactureFournisseurRepo : IFactureFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<FactureFournisseur> genericRepository;

        public FactureFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<FactureFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public IEnumerable<FactureFournisseur> GetAll(string id)
        {
            var list = bigSoftContext.FactureFournisseurs
                  .Include(x => x.BonDeReceptionFournisseur)
                  .ThenInclude(x => x.Fournisseur)
                  .Include(x => x.BonDeReceptionFournisseur)
                  .ThenInclude(x => x.Grossiste)
                  .Include(w => w.DetailsFactures)
                  .Include(x => x.BonDeReceptionFournisseur)
                  .ThenInclude(x => x.DetailsReceptions)
                  .ThenInclude(x=>x.Produit)
                  .Where(x => x.BonDeReceptionFournisseur.GrossisteId == id);
            return list;
        }

        public async Task<FactureFournisseur> GetById(int id)
        {
            var entity = await bigSoftContext.FactureFournisseurs
                .Include(x => x.DetailsFactures)
                .Include(x => x.BonDeReceptionFournisseur)
                .ThenInclude(x => x.Grossiste)
                .Include(x => x.BonDeReceptionFournisseur)
                .ThenInclude(w => w.Fournisseur)
                .Include(x => x.BonDeReceptionFournisseur)
                .ThenInclude(x => x.DetailsReceptions)
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task PutAsync(int id, FactureFournisseur entity)
        {
            var facture = await bigSoftContext.FactureFournisseurs.SingleOrDefaultAsync(x => x.Id == id);
            facture.PrixTotaleHt = entity.PrixTotaleHt;
            facture.PrixTotaleTTc = entity.PrixTotaleTTc;
            facture.Date = entity.Date;
            facture.DetailsFactures = entity.DetailsFactures;

            try
            {
                bigSoftContext.FactureFournisseurs.Update(facture);
                await bigSoftContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
