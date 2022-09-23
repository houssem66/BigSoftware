using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IDevisClientService
    {
        public Task Update(int id, Devis entity);
        public Task<Devis> GetById(int id);
        public Task Delete(int id);
        public List<Devis> GetAll();
        public Task Ajout(Devis entity);
    }
}

