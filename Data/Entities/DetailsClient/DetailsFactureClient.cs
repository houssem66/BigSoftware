using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DetailsFactureClient
    {
        public int IdProduit { get; set; }
        public Produit Produit { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal Montant { get; set; }
        public int IdFactureClient { get; set; }
        public FactureClient FactureClient { get; set; }
    }
}
