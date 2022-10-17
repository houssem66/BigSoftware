using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProduitService
    {
        public Task Update(int id, Produit entity);
        public Task<Produit> GetById(int id);
        public Task Delete(int id);
        public List<Produit> GetAll();
        public Task Ajout(Produit entity);
    }
}
