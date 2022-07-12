using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClientService
    {
        public Task Ajout(Client entity);
        public Task Update(Client entity);
        public Task<Client> GetById(int id);
        public Task Delete(int id);
    }
}
