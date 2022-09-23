using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DetailsBonSortie
    {
        public int IdProduit { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal Montant { get; set; }
        public Produit Produit { get; set; }
        public int IdBonSortie { get; set; }
        public BonSortie BonSortie { get; set; }
    }
}
