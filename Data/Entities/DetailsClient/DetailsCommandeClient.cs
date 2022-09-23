using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DetailsCommandeClient
    {
        public int IdProduit { get; set; }
        public Decimal Montant { get; set; }
        public Decimal Quantite { get; set; }
        public Produit Produit { get; set; }
        public int IdCommande { get; set; }
        public BonCommandeClient CommandeClient { get; set; }
    }
}
