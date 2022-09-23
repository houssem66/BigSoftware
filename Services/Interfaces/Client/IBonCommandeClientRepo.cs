using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IBonCommandeClientService
    {
        public Task Update(int id, BonCommandeClient entity);
        public Task<BonCommandeClient> GetById(int id);
        public Task Delete(int id);
        public List<BonCommandeClient> GetAll();
        public Task Ajout(BonCommandeClient entity);
    }
}
