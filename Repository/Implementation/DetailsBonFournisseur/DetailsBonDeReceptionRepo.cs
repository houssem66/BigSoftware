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
    public class DetailsBonDeReceptionRepo:IDetailsBonReceptionFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsReceptionFournisseur> genericRepository;

        public DetailsBonDeReceptionRepo(BigSoftContext _bigSoftContext, IGenericRepository<DetailsReceptionFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
