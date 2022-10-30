using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class FactureFournisseurRepo : RepositoryBase<FactureFournisseur>, IFactureFournisseurRepo
    {
 

        public FactureFournisseurRepo(BigSoftContext bigSoftContext):base(bigSoftContext)
        {
           
        }

   
    }
}
