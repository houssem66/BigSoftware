using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IDetailsCommandeClientService
    {
        public Task Update(int id, DetailsCommandeClient entity);
        public Task<DetailsCommandeClient> GetById(int id);
        public Task Delete(int id);
        public List<DetailsCommandeClient> GetAll();
        public Task Ajout(DetailsCommandeClient entity);
    }
}
