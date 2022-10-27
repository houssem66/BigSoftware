using Data.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace Services.Interfaces
{
    public interface IDetailsLivraisonClientService
    {
        public Task Update(int id, DetailsLivraisonClient entity);
        public Task<DetailsLivraisonClient> GetById(int id);
        public Task Delete(int id);
        public List<DetailsLivraisonClient> GetAll();
        public Task Ajout(DetailsLivraisonClient entity);
    }
}
