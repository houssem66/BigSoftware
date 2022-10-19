using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IBonDeReceptionFournisseurService
    {
        public Task Update(int id, BonDeReceptionFournisseur entity);
        public Task<BonDeReceptionFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<BonDeReceptionFournisseur> GetAll(string id);
        public Task Ajout(BonDeReceptionFournisseur entity);
    }
}
