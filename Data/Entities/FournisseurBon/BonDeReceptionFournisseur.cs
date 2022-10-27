using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BonDeReceptionFournisseur
    {
        [Key]
        public int Id { get; set; }
        public int FournisseurId { get; set; }
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public Boolean Confirmed { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsReceptionFournisseur> DetailsReceptions { get; set; }
        public BonDeReceptionFournisseur()
        {
            Confirmed = false;
        }
    }
}
