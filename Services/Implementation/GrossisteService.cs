using Data.Entities;
using Repository.Implementation;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class GrossisteService : IGrossisteService
    {
        private readonly IGenericRepository<Grossiste> genericRepo;
        private readonly IGrossiteRepo grossisteRepo;

        public GrossisteService(IGenericRepository<Grossiste> _GenericRepo, IGrossiteRepo _GrossisteRepo)
        {
            genericRepo = _GenericRepo;
            grossisteRepo = _GrossisteRepo;
        }
        public Task Ajout(Grossiste entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grossiste> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Grossiste entity)
        {
            throw new NotImplementedException();
        }
    }
}
