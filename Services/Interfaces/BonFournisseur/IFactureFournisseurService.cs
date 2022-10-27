using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IFactureFournisseurService
    {
        public Task Update(int id, FactureFournisseur entity);
        public Task<FactureFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<FactureFournisseur> GetAll();
        public Task Ajout(FactureFournisseur entity);
    }
}
