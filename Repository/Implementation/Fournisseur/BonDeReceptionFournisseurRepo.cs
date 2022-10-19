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
            return bigSoftContext.BonDeRéceptionFournisseurs.Where(e => e.GrossisteId == id);
        }

        public async Task PutAsync(int id, BonDeReceptionFournisseur entity)
        {
            var bon = await bigSoftContext.BonDeRéceptionFournisseurs.SingleAsync(x => x.Id == id);
            bon.Date = entity.Date;
            bon.DetailsReceptions = entity.DetailsReceptions;
            bon.PrixTotaleHt = bon.PrixTotaleHt;
            bon.PrixTotaleTTc = bon.PrixTotaleTTc;
            
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
