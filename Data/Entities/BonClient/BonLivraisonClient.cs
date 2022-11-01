using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class BonLivraisonClient
    {
        [Key]
        public int Id { get; set; }
      
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string GrossisteId { get; set; }
        public Boolean Confirmed { get; set; }
        public virtual Client Client { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public virtual FactureClient FactureClient { get; set; }
        public virtual ICollection<DetailsLivraisonClient> DetailsLivraisons { get; set; }
    }
}
