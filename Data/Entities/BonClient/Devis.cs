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
    public class Devis
    {
        private readonly BigSoftContext context;

        public Devis()
        {

        }

         
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsDevis?.Sum(x => x.MontantTTc)
            ?? context.Set<DetailsDevis>().Where(x => x.IdDevis == Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsDevis?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsDevis>().Where(x => x.IdDevis == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public virtual Client Client { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsDevis> DetailsDevis { get; set; }
        private Devis(BigSoftContext context)
        {
            this.context = context;
        }


    }
}
