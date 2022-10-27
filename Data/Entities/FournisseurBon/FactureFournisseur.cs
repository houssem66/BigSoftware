using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class FactureFournisseur
    {
        [Key]
        public int Id { get; set; }
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public virtual BonDeReceptionFournisseur BonDeReceptionFournisseur { get; set; }
        public  int BonDeReceptionId { get; set; }
      
        public virtual ICollection<DetailsFactureFournisseur> DetailsFactures { get; set; }

    }
}
