using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ProduitRepo : RepositoryBase<Produit>, IProduitRepo
    {

        public ProduitRepo(BigSoftContext _bigSoftContext) : base(_bigSoftContext)
        {

        }
       
    }
}
