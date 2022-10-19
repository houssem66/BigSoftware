using System;

namespace Data.Models
{
  public  class DetailsBonReceptionModel
    {
        public int IdProduit { get; set; }
        public int IdBonReception { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal MontantTTc { get; set; }
        public Decimal MontantHt { get; set; }

    }
}
