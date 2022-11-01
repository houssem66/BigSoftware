using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class BonDeReceptionFournisseur
    {
        [Key]
        public int Id { get; set; }
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public Boolean Confirmed { get; set; }
        public int FournisseurId { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
        public string GrossisteId { get; set; }

        public virtual Grossiste Grossiste { get; set; }
        public virtual ICollection<DetailsReceptionFournisseur> DetailsReceptions { get; set; }
        public FactureFournisseur FactureFournisseur { get; set; }


    }
}
