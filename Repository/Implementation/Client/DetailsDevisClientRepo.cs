using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class DetailsDevisClientRepo:IDetailsDevisClientRepo
    {
        public DetailsDevisClientRepo(BigSoftContext _bigSoftContext, IGenericRepository<DetailsDevis> _genericRepository)
        {

        }
    }
}
