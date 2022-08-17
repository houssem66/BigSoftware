using Data.Entities;
using Data.Models;
using Repository.Implementation;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Implementation
{
    public class FournisseurService : IFournisseurService
    {
        private readonly IGenericRepository<Fournisseur> genericRepo;
        private readonly IFournisseurRepo FournisseurRepo;

        public FournisseurService(IGenericRepository<Fournisseur> _GenericRepo, IFournisseurRepo _FournisseurRepo)
        {
            genericRepo = _GenericRepo;
            FournisseurRepo = _FournisseurRepo;
        }
        public Task Ajout(Fournisseur entity)
        {
            return genericRepo.InsertAsync(entity);
        }

        public Task Delete(string id)
        {
            return genericRepo.DeleteAsync(id);
        }

        public Task<Fournisseur> GetById(string id)
        {
            return genericRepo.GetByIdAsync(id);
        }

        public Task Update(string id,Fournisseur entity)
        {
            return genericRepo.PutAsync(id, entity);
        }
        public List<Fournisseur> GetAll()
        {
            return genericRepo.GetAll().ToList();
        }

       

       
    }
}
