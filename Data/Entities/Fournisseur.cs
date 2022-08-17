using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
   public class Fournisseur
    {[Key]
        public int Id { get; set; }
        public string NomPersAContact { get; set; }
        public string RaisonSocial { get; set; }
        public string PrenomPersAContact { get; set; }
       
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }
        public string Email { get; set; }
        public string SiteWeb { get; set; }
        public int Numbureau { get; set; }
        public int NumFax { get; set; }
        public String Adresse { get; set; }
    }
}
