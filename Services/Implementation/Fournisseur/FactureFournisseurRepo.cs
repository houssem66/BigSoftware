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
    public class FactureFournisseurRepo:IFactureFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<FactureFournisseur> genericRepository;

        public FactureFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<FactureFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
