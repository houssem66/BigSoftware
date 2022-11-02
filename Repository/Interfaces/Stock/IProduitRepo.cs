using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProduitRepo : IRepositoryBase<Produit>
    {
    
        Task<IList<Produit>> UpdateAll(int id,Produit entity);
    }
}
