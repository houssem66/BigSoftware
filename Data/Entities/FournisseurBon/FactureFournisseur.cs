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
        public int FournisseurId { get; set; }
        public Decimal Prix { get; set; }
        public DateTime Date { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public int GrossisteId { get; set; }
        public virtual ICollection<DetailsFactureFournisseur> DetailsFactures { get; set; }

    }
}
