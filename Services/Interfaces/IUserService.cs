using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
  public  interface IUserService
    {
        public Task<AuthModel> RegisterAsync(RegisterModelUser model);
        public Task Update(string id, Utilisateur entity);
        public List<Utilisateur> GetAll();
        public Task<Utilisateur> GetById(string id);
        public Task<Utilisateur> GetByEmail(string email);
        public Task<Utilisateur> GetByUserName(string UserName);
        public Task Delete(string id);
        public Task<AuthModel> Login(TokenRequestModel model);


    }
}
