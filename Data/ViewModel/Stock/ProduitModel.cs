using Data.Entities.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class ProduitModel
    {
        public string Message { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile photo { get; set; }
        public TypePrix TypePrix { get; set; }
        public TVA TVA { get; set; }
        public decimal? PriceTTc => ((decimal)TVA/100 )* PriceHt+PriceHt;
        public decimal? PriceHt { get; set; }
        public Category Category { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
