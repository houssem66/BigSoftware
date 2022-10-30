using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class BonCommandeFModel
    {
        public int FournisseurId { get; set; }
        public string GrossisteId { get; set; }
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public IList<DetailsBonCommandeFModel> DetailsBonCommandes { get; set; }
    }
}
