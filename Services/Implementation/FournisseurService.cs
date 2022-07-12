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
    public class FournisseurService : IFournisseurService
    {
        private readonly IGenericRepository<Fournisseur> genericRepo;
        private readonly IGrossiteRepo FournisseurRepo;

        public FournisseurService(IGenericRepository<Fournisseur> _GenericRepo, IGrossiteRepo _FournisseurRepo)
        {
            genericRepo = _GenericRepo;
            FournisseurRepo = _FournisseurRepo;
        }
        public Task Ajout(Fournisseur entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Fournisseur> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Fournisseur entity)
        {
            throw new NotImplementedException();
        }
    }
}
