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
    public class DetailsLivraisonClientRepo:IDetailsLivraisonClientRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<DetailsLivraisonClient> genericRepository;

        public DetailsLivraisonClientRepo(BigSoftContext _bigSoftContext, IGenericRepository<DetailsLivraisonClient> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
