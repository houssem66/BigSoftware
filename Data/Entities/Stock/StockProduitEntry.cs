using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class StockProduitEntry
    {
        public int Id { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime EndDate { get; set; }
        public int idProdFK { get; set; }
        public int idStockFK { get; set; }
        public virtual StockProduit StockProduit { get; set; }

    }
}
