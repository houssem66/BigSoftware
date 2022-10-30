using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace Repository.Implementation
{
    public class FournisseurRepo:IFournisseurRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Fournisseur> genericRepository;

       
      
        public FournisseurRepo(BigSoftContext _bigSoftContext, IGenericRepository<Fournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
           
          
          
        }

        public IEnumerable<Fournisseur> GetAll(string id)
        {
            return bigSoftContext.Fournisseurs.Where(e => e.IdGrossiste == id);
        }
    }
}
