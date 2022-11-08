using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Data.Entities
{
    public class BonLivraisonClient
    {
        private readonly BigSoftContext context;

        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsLivraisons?.Sum(x => x.MontantTTc) 
            ?? context.Set<DetailsLivraisonClient>().Where(x => x.IdBonLivraison == Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsLivraisons?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsLivraisonClient>().Where(x => x.IdBonLivraison == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string GrossisteId { get; set; }
        public Boolean Confirmed { get; set; }
        public virtual Client Client { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public virtual FactureClient FactureClient { get; set; }
        public virtual ICollection<DetailsLivraisonClient> DetailsLivraisons { get; set; }
        public BonLivraisonClient()
        {

        }
        private BonLivraisonClient(BigSoftContext context)
        {
            this.context = context;
        }
    }
}
