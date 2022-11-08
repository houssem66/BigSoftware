using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Stock
    {
        private readonly BigSoftContext context;

        public Stock()
        {

        }
        private Stock(BigSoftContext context)
        {
            this.context = context;
        }
        public string StoreName { get; set; }
     
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public Decimal? Sum => StockProduit?.Sum(x => x.PrixTotaleTTc) 
            ?? context.Set<StockProduit>().Where(x => x.IdStock == Id).Sum(x => x.PrixTotaleTTc) ?? 0;
        public virtual ICollection<StockProduit> StockProduit { get; set; }
        public virtual  Grossiste Grossiste { get; set; }
    }
}
