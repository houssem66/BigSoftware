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
        public Task Update(Utilisateur entity);
        public List<Utilisateur> GetAll();
        public Task<Utilisateur> GetById(int id);
        public Task Delete(int id);
        public Task<AuthModel> Login(TokenRequestModel model);


    }
}
