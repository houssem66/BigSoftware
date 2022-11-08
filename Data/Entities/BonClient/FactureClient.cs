using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FactureClient
    {
        private readonly BigSoftContext context;

        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsFactures?.Sum(x => x.MontantTTc) 
            ?? context.Set<DetailsFactureClient>().Where(x => x.IdFactureClient == Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsFactures?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsFactureClient>().Where(x => x.IdFactureClient == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public  int BonLivraisonId { get; set; }
        public virtual BonLivraisonClient BonLivraisonClient { get; set; }
        public virtual ICollection<DetailsFactureClient> DetailsFactures { get; set; }
        public FactureClient()
        {

        }
        public FactureClient(BigSoftContext context)
        {
            this.context = context;
        }
    }
}
