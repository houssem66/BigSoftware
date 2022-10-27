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
    public class BonDeCommandeFournisseurRepo:IBonDeCommandeFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<BonDeCommandeFournisseur> genericRepository;

        public BonDeCommandeFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<BonDeCommandeFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
