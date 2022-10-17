using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;


namespace Services.Interfaces
{
    public interface IDetailsFactureFournisseurService
    {
        public Task Update(int id, DetailsFactureFournisseur entity);
        public Task<DetailsFactureFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<DetailsFactureFournisseur> GetAll();
        public Task Ajout(DetailsFactureFournisseur entity);
    }
}
