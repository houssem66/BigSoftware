using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class FactureFournisseur
    {
        private readonly BigSoftContext context;

        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsFactures?.Sum(x => x.MontantTTc) ?? context.Set<DetailsFactureFournisseur>().Where(x => x.IdFacutre == Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsFactures?.Sum(x => x.MontantHt) ?? context.Set<DetailsFactureFournisseur>().Where(x=>x.IdFacutre==Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public virtual BonDeReceptionFournisseur BonDeReceptionFournisseur { get; set; }
        public  int BonDeReceptionId { get; set; }
      
        public virtual ICollection<DetailsFactureFournisseur> DetailsFactures { get; set; }
        public FactureFournisseur()
        {
                
        }
        private FactureFournisseur(BigSoftContext context)
        {
            this.context = context;
        }
    }
}
