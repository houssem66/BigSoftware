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
        public Decimal Quantité { get; set; }
        public Decimal PrixTotale { get; set; }
        public Produit Produit { get; set; }
        public Stock Stock { get; set; }
    }
}
