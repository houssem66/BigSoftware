using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Repository.Interfaces
{
    public interface IFournisseurRepo
    {
        public Task<AuthModel> RegisterAsync(RegisterModelFournisseur model);
        public Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    }
}
