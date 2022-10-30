using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class BonReceptionModel
    {
        public int FournisseurId { get; set; }
        public string GrossisteId { get; set; }
        public Decimal PrixTotaleTTc { get; set; }
        public Decimal PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public IList<DetailsBonReceptionModel> DetailsBonReceptionModels { get; set; }
    }
}
