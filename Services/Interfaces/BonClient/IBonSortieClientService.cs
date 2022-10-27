using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IBonSortieClientService
    {
        public Task Update(int id, BonSortie entity);
        public Task<BonSortie> GetById(int id);
        public Task Delete(int id);
        public List<BonSortie> GetAll();
        public Task Ajout(BonSortie entity);
    }
}
