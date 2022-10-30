﻿using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Implementation
{
    public class BonLivraisonClientRepo: RepositoryBase<BonLivraisonClient>, IBonLivraisonClientRepo
    {
        public BonLivraisonClientRepo(BigSoftContext _bigSoftContext) : base(_bigSoftContext)
        {

        }
    }
}
