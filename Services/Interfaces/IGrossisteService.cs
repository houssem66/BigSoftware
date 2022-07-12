using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Services.Interfaces
{
    public interface IGrossisteService
    {
        public Task Ajout(Grossiste entity);
        public Task Update(Grossiste entity);
        public Task<Grossiste> GetById(int id);
        public Task Delete(int id);
    }
}
