using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IDetailsBonSortieClientService
    {
        public Task Update(int id, DetailsBonSortie entity);
        public Task<DetailsBonSortie> GetById(int id);
        public Task Delete(int id);
        public List<DetailsBonSortie> GetAll();
        public Task Ajout(DetailsBonSortie entity);
    }
}
