﻿using Data;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class FactureFournisseurService:IFactureFournisseurService
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<FactureFournisseur> genericRepository;

        public FactureFournisseurService(BigSoftContext _bigSoftContext, IGenericRepository<FactureFournisseur> _genericRepository)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
        }

        public Task Ajout(FactureFournisseur entity)
        {
            return genericRepository.InsertAsync(entity);
        }

        public Task Delete(int id)
        {
            return genericRepository.DeleteAsync(id);
        }

        public List<FactureFournisseur> GetAll()
        {
            return genericRepository.GetAll().ToList();
        }

        public Task<FactureFournisseur> GetById(int id)
        {
            return genericRepository.GetByIdAsync(id);
        }

        public Task Update(int id, FactureFournisseur entity)
        {
            return genericRepository.PutAsync(id, entity);
        }
    }
}
