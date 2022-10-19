using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class DetailsFactureFournisseur
    {
        public int IdProduit { get; set; }
        public int IdFacutre { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal MontantTTc { get; set; }
        public Decimal MontantHt { get; set; }
        public Produit Produit { get; set; }
        public virtual FactureFournisseur FactureFournisseur { get; set; }
    }
}
