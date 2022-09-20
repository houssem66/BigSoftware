using Data.Entities.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public TypePrix TypePrix { get; set; }
        public TVA TVA { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<StockProduit> StockProduit { get; set; }
        public virtual ICollection<DetailsCommandeFournisseur> DetailsCommandes { get; set; }
        public virtual ICollection<DetailsFactureFournisseur> DetailsFactures { get; set; }
        public virtual ICollection<DetailsReceptionFournisseur> DetailsReceptions { get; set; }

    }
}
