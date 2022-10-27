using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;


namespace Services.Interfaces
{
    public interface IDetailsBonCommandeFournisseurService
    {
        public Task Update(int id, DetailsCommandeFournisseur entity);
        public Task<DetailsCommandeFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<DetailsCommandeFournisseur> GetAll();
        public Task Ajout(DetailsCommandeFournisseur entity);
    }
}
