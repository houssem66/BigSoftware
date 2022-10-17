using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStockRepo
    {
        public Task PutAsync(int id, Stock entity);

    }
}
