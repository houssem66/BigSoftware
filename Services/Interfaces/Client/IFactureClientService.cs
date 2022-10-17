using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IFactureClientService
    {
        public Task Update(int id, FactureClient entity);
        public Task<FactureClient> GetById(int id);
        public Task Delete(int id);
        public List<FactureClient> GetAll();
        public Task Ajout(FactureClient entity);
    }
}
