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
    public class FactureFournisseurRepo:IFactureFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<FactureFournisseur> genericRepository;

        public FactureFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<FactureFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
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
