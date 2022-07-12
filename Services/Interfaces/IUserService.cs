using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public  interface IUserService
    {
        public Task Ajout(Utilisateur entity);
        public Task Update(Utilisateur entity);
        public Task<Utilisateur> GetById(int id);
        public Task Delete(int id);
    }
}
