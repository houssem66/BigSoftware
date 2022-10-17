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
    public class DetailsBonCommandeFournisseurRepo:IDetailsBonCommandeFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsCommandeFournisseur> genericRepository;

        public DetailsBonCommandeFournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<DetailsCommandeFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
