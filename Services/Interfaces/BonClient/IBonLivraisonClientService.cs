using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IBonLivraisonClientService
    {
        public Task Update(int id, BonLivraisonClient entity);
        public Task<BonLivraisonClient> GetById(int id);
        public Task Delete(int id);
        public List<BonLivraisonClient> GetAll();
        public Task Ajout(BonLivraisonClient entity);
    }
}
