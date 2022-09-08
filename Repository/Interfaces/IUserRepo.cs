using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Repository.Interfaces
{
   public interface IUserRepo
    {
       public Task<AuthModel> RegisterAsync(RegisterModelUser model);
     public   Task<AuthModel> GetTokenAsync(TokenRequestModel model);
     public   Task<Utilisateur> getUserByEmail(string email);
    }
}
