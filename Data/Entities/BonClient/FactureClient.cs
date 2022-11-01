using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FactureClient
    {
        [Key]
        public int Id { get; set; }
       
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public  int BonLivraisonId { get; set; }
        public virtual BonLivraisonClient BonLivraisonClient { get; set; }
        public virtual ICollection<DetailsFactureClient> DetailsFactures { get; set; }
    }
}
