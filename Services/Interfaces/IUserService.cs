using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
  public  interface IUserService
    {
        public Task<AuthModel> RegisterAsync(RegisterModelUser model);
        public Task Update(Utilisateur entity);
        public Task<Utilisateur> GetById(int id);
        public Task Delete(int id);
        public Task<Utilisateur> Login(Utilisateur entity);

    }
}
