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
    public class BonDeReceptionFournisseurRepo:IBonDeReceptionFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonDeReceptionFournisseur> genericRepository;

        public BonDeReceptionFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<BonDeReceptionFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public Task PutAsync(int id, BonDeReceptionFournisseur entity)
        {
            throw new NotImplementedException();
        }
    }
}
