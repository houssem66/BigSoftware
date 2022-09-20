using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class DetailsReceptionFournisseur
    {
        public int IdProduit { get; set; }
        public int IdBonReception { get; set; }
        public Produit Produit   { get; set; }
        public BonDeRéceptionFournisseur BonDeRéception { get; set; }
    }
}
