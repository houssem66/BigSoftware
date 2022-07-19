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
        public Task<AuthModel> RegisterAsync(RegisterModelClient model);
        public Task<AuthModel> Login(TokenRequestModel model);
        public Task Update(string id,Client entity);
        public Task<Client> GetById(string id);
        public Task Delete(string id);
        public List<Client> GetAll();
    }
}
