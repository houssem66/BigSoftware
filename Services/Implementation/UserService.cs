using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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
       
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> Login(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

        public Task<AuthModel> RegisterAsync(RegisterModelUser model)
        {
            return userRepo.RegisterAsync(model);
        }

        public Task Update(Utilisateur entity)
        {
            throw new NotImplementedException();
        }

      
    }
}
