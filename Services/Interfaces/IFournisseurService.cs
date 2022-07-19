using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace Services.Interfaces
{
    public interface IFournisseurService
    {
        public Task<AuthModel> RegisterAsync(RegisterModelFournisseur model);
        public Task<AuthModel> Login(TokenRequestModel model);
        public Task Update(string id, Fournisseur entity);
        public Task<Fournisseur> GetById(string id);
        public Task Delete(string id);
        public List<Fournisseur> GetAll();
    }
}
