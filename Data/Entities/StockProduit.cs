using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class StockProduit
    {
        public int IdProduit { get; set; }
        public int IdStock { get; set; }
        public Decimal PrixTotale { get; set; }
        public Decimal Quantite { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
