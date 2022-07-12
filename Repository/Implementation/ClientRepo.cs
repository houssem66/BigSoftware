using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class ClientRepo:IClientRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Client> genericRepository;

        public ClientRepo(BigSoftContext _bigSoftContext,IGenericRepository<Client> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
