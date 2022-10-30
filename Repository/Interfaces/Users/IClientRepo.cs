using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Repository.Interfaces
{
    public interface IClientRepo: IRepositoryBase<Client>
    {
        public IEnumerable<Client> GetAll(string id);

    }
}
