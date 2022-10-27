using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;


namespace Services.Interfaces
{
    public interface IDetailsBonDeReceptionFournisseurService
    {
        public Task Update(int id, DetailsReceptionFournisseur entity);
        public Task<DetailsReceptionFournisseur> GetById(int id);
        public Task Delete(int id);
        public List<DetailsReceptionFournisseur> GetAll();
        public Task Ajout(DetailsReceptionFournisseur entity);
    }
}
