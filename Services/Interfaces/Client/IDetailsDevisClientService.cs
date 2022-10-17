using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IDetailsDevisClientService
    {
        public Task Update(int id, DetailsDevis entity);
        public Task<DetailsDevis> GetById(int id);
        public Task Delete(int id);
        public List<DetailsDevis> GetAll();
        public Task Ajout(DetailsDevis entity);
    }
}
