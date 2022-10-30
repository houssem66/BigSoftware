using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class StockRepo : RepositoryBase<Stock>, IStockRepo
    {
     

        public StockRepo(BigSoftContext _bigSoftContext):base(_bigSoftContext)
        {
           
        }

      
        
    }
}
