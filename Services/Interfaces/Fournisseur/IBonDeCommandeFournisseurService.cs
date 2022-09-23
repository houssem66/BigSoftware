using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IBonDeCommandeFournisseurService
    {
        public Task Update(int id, BonDeCommandeFournisseur entity);
        public Task<BonDeCommandeFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<BonDeCommandeFournisseur> GetAll();
        public Task Ajout(BonDeCommandeFournisseur entity);
    }
}
