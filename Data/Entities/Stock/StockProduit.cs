using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class StockProduit
    {
        private readonly BigSoftContext context;

        public StockProduit()
        {

        }
        public StockProduit(BigSoftContext context)
        {
            this.context = context;
        }
        public int IdProduit { get; set; }
        public int IdStock { get; set; }
        public decimal? PrixTotaleTTc => Produit.PriceTTc * Quantite ?? context.Set<Produit>().Where(x => x.Id == IdProduit).Single().PriceTTc * Quantite ?? 0;
        public decimal? PrixTotaleHt => Produit.PriceHt * Quantite ?? context.Set<Produit>().Where(x => x.Id == IdProduit).Single().PriceHt * Quantite ?? 0;
        public decimal? Quantite => StockProduitEntries?.Sum(x => x.Quantity)
           ?? context.Set<StockProduitEntry>().Where(x => x.idProdFK == IdProduit && x.idStockFK == IdStock).Sum(x => x.Quantity) ?? 0;
        public virtual Produit Produit { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<StockProduitEntry> StockProduitEntries { get; set; }
    }
}
