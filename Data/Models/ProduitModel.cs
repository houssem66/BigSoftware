using Data.Entities.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class ProduitModel
    {
        public string Message { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public TypePrix TypePrix { get; set; }
        public TVA TVA { get; set; }
        public decimal? PriceHT { get; set; }
        public Category Category { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
