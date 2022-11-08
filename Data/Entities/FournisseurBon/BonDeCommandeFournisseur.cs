using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class BonDeCommandeFournisseur
    {
        private readonly BigSoftContext context;

        [Key]
        public int Id { get; set; }
        public int FournisseurId { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc  => DetailsCommandes?.Sum(x => x.MontantTTc) 
            ?? context.Set<DetailsCommandeFournisseur>().Where(x=>x.IdBonCommande==Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsCommandes?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsCommandeFournisseur>().Where(x => x.IdBonCommande == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsCommandeFournisseur> DetailsCommandes { get; set; }
        public BonDeCommandeFournisseur()
        {

        }
        private BonDeCommandeFournisseur(BigSoftContext context)
        {
            this.context = context;
        }

    }
}
