using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class DetailsCommandeFournisseur
    {
        public int IdProduit { get; set; }
        public int IdBonCommande { get; set; }
        public Decimal? Quantite { get; set; }
        public Decimal? MontantTTc { get; set; }
        public Decimal? MontantHt { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual BonDeCommandeFournisseur BonDeCommandeFournisseur { get; set; }
    }
}
