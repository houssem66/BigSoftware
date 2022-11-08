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
   public class BonSortie
    {
        private readonly BigSoftContext context;

        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [NotMapped]
        public Decimal? PrixTotaleTTc => DetailsBonSorties?.Sum(x => x.MontantTTc)
            ?? context.Set<DetailsBonSortie>().Where(x=>x.IdBonSortie==Id).Sum(s => s.MontantTTc) ?? 0;
        [NotMapped]
        public Decimal? PrixTotaleHt => DetailsBonSorties?.Sum(x => x.MontantHt) 
            ?? context.Set<DetailsBonSortie>().Where(x => x.IdBonSortie == Id).Sum(s => s.MontantHt) ?? 0;
        public DateTime Date { get; set; }
        public  Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsBonSortie> DetailsBonSorties { get; set; }

        public BonSortie()
        {

        }
        private BonSortie(BigSoftContext context)
        {
            this.context = context;
        }
    }
}
