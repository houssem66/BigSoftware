using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBonDeReceptionFournisseurRepo
    {
        public Task PutAsync(int id, BonDeReceptionFournisseur entity);
        public Task<BonDeReceptionFournisseur> GetById(int id,string include);
        public Task<BonDeReceptionFournisseur> GetById(int id);
        public IEnumerable<BonDeReceptionFournisseur> GetAll(string id);


    }
}
