using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Data.Entities
{
    public class BonDeReceptionFournisseur
    {
        private readonly BigSoftContext bigSoftContext;

        public BonDeReceptionFournisseur()
        {
        }
        private BonDeReceptionFournisseur(BigSoftContext bigSoftContext)
        {
            this.bigSoftContext = bigSoftContext;
        }
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsReceptions?
            .Sum(x => x.MontantTTc) ?? bigSoftContext
            .Set<DetailsReceptionFournisseur>().Where(x=>x.IdBonReception==Id)
            .Sum(x => x.MontantTTc) ?? 0;
          
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsReceptions?.Sum(x => x.MontantHt)
            ?? bigSoftContext.Set<DetailsReceptionFournisseur>()
            .Where(x => x.IdBonReception == Id).Sum(x => x.MontantHt)
            ?? 0;
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
