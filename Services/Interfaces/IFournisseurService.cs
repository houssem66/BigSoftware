using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Services.Interfaces
{
    public interface IFournisseurService
    {
        public Task Ajout(Fournisseur entity);
        public Task Update(Fournisseur entity);
        public Task<Fournisseur> GetById(int id);
        public Task Delete(int id);
    }
}
