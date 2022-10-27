﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFactureFournisseurRepo
    {
        public Task PutAsync(int id, FactureFournisseur entity);
        public Task<FactureFournisseur> GetById(int id);
        public IEnumerable<FactureFournisseur>  GetAll(string id);

    }
}
