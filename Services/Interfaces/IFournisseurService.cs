using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IFournisseurService
    {
    
        public Task Update(string id, Fournisseur entity);
        public Task<Fournisseur> GetById(string id);
        public Task Delete(string id);
        public List<Fournisseur> GetAll();
        public Task Ajout(Fournisseur entity);
    }
}
