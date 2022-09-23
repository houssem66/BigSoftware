using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IDetailsFactureClientService
    {
        public Task Update(int id, DetailsFactureClient entity);
        public Task<DetailsFactureClient> GetById(int id);
        public Task Delete(int id);
        public List<DetailsFactureClient> GetAll();
        public Task Ajout(DetailsFactureClient entity);
    }
}
