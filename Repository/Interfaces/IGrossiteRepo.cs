using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Repository.Interfaces
{
    public interface IGrossiteRepo
    {
        public Task<AuthModel> RegisterAsync(RegisterModelGrossiste model);
        public Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        public Task PutAsync(string id, Grossiste entity);

    }
}
