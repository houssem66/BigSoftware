using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class BonCommandeCModel
    {
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string GrossisteId { get; set; }
        public IList<DetailsCommandeCModel> DetailsBonCommandes { get; set; }
    }
}
