using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class GrossisteRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Grossiste> genericRepository;

        public GrossisteRepo(BigSoftContext _bigSoftContext, IGenericRepository<Grossiste> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }
    }
}
