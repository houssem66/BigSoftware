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
    public class ProduitRepo:IProduitRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Produit> genericRepository;

        public ProduitRepo(BigSoftContext _bigSoftContext, IGenericRepository<Produit> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
