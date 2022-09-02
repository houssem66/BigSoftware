using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IClientService
    {
       
        public Task Update(int id,Client entity);
        public Task<Client> GetById(int id);
        public Task Delete(int id);
        public List<Client> GetAll();
        public Task Ajout(Client entity);
    }
}
