using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Stock
    {
        public string StoreName { get; set; }
     
        [Key]
        public int Id { get; set; }
        public virtual ICollection<StockProduit> StockProduit { get; set; }
        public virtual  Grossiste Grossiste { get; set; }
    }
}
