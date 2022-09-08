using Data.Entities;
using Data.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Utilisateur> genericRepo;
        private readonly IUserRepo userRepo;

        public UserService(IGenericRepository<Utilisateur> _GenericRepo,IUserRepo _UserRepo)
        {
            genericRepo = _GenericRepo;
            userRepo = _UserRepo;
        }
       
        public Task Delete(string id)
        {
            return genericRepo.DeleteAsync(id);
        }

        public List<Utilisateur> GetAll()
        {
            return genericRepo.GetAll().ToList();
        }

        public Task<Utilisateur> GetByEmail(string email)
        {
            return userRepo.getUserByEmail(email);
        }

        public Task<Utilisateur> GetById(string id)
        {
            return genericRepo.GetByIdAsync(id);
        }

        public Task<AuthModel> Login(TokenRequestModel model)
        {
            return userRepo.GetTokenAsync(model);
        }

        public Task<AuthModel> RegisterAsync(RegisterModelUser model)
        {
            return userRepo.RegisterAsync(model);
        }

        public Task Update(string id, Utilisateur entity)
        {
            return genericRepo.PutAsync(id, entity);
        }

      
    }
}
