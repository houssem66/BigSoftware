using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Data.Entities
{
    public class BonCommandeClient
    {
        private readonly BigSoftContext context;
        public BonCommandeClient()
        {

        }
        private BonCommandeClient(BigSoftContext context)
        {
            this.context = context;
        }
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsCommandes?.Sum(x => x.MontantTTc)
            ??context.Set<DetailsCommandeClient>().Where(x=>x.IdCommande==Id).Sum(s=>s.MontantTTc)??0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsCommandes?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsCommandeClient>().Where(x => x.IdCommande == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsCommandeClient> DetailsCommandes { get; set; }
     

    }
}
