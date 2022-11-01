using System;

namespace Data.Models
{
    public class DetailsDevisModel
    {
        public int IdProduit { get; set; }
        public Decimal? Quantite { get; set; }
        public Decimal? MontantTTc { get; set; }
        public Decimal? MontantHt { get; set; }
        public int IdDevis { get; set; }
    }
}