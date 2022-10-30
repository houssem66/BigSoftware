using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace Repository.Implementation
{
    public class ClientRepo : RepositoryBase<Client>, IClientRepo
    {
      

        public ClientRepo(BigSoftContext _bigSoftContext):base(_bigSoftContext)
        {
           
           
        }

        public IEnumerable<Client> GetAll(string id)
        {
            return BigSoftContext.Clients.Include(x=>x.Grossiste);
        }
    }



   
   
}
