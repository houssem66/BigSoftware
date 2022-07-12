using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
   public class UserRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Utilisateur> genericRepository;

        public UserRepo(BigSoftContext _bigSoftContext, IGenericRepository<Utilisateur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
