using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IGrossisteService
    {
        public Task<AuthModel> RegisterAsync(RegisterModelGrossiste model);
        public Task<AuthModel> Login(TokenRequestModel model);
        public Task Update(string id, Grossiste entity);
        public Task<Grossiste> GetById(string id);
        public Task Delete(string id);
        public List<Grossiste> GetAll();
    }
}
