using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class DetailsLivraisonClient
    {
        public int IdProduit { get; set; }
        public virtual Produit Produit { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal MontantTTc { get; set; }
        public Decimal MontantHt { get; set; }
        public int IdBonLivraison { get; set; }
        public virtual BonLivraisonClient BonLivraison { get; set; }
    }
}
