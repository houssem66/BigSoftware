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
    public class BonDeReceptionFournisseurRepo : RepositoryBase<BonDeReceptionFournisseur>, IBonDeReceptionFournisseurRepo
    {

        public BonDeReceptionFournisseurRepo(BigSoftContext bigSoftContext) :base(bigSoftContext)
        {
          
        }

    }
}
