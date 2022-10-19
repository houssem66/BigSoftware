using Data.Entities;
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
        public TVA TVA { get; set; }
        public decimal? PriceTTc { get; set; }
        public decimal? PriceHt { get; set; }
        public Category Category { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<StockProduit> StockProduit { get; set; }
        //Details Fournisseur
        public virtual ICollection<DetailsCommandeFournisseur> DetailsCommandes { get; set; }
        public virtual ICollection<DetailsFactureFournisseur> DetailsFactures { get; set; }
        public virtual ICollection<DetailsReceptionFournisseur> DetailsReceptions { get; set; }
        //Details Client
        public virtual ICollection<DetailsFactureClient> DetailsFactureClients { get; set; }
        public virtual ICollection<DetailsCommandeClient> DetailsCommandeClients { get; set; }
        public virtual ICollection<DetailsLivraisonClient> DetailsLivraisons { get; set; }
        public virtual ICollection<DetailsDevis> DetailsDevis { get; set; }
        public virtual ICollection<DetailsBonSortie> DetailsBonSorties { get; set; }


    }
}
