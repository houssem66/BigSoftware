using Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
   public class Grossiste:Utilisateur
    {
        [Required]
        public string RaisonSocial { get; set; }
        public string NomPersAContact { get; set; }
        public string PrenomPersAContact { get; set; }
        [DefaultValue(false)]
        public Boolean Verified { get; set; }
        [RegularExpression(@"([0-9]{20})", ErrorMessage = "Must be a Number.")]
        [StringLength(20, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Rib { get; set; }
        // ajouté le 11/06/2021
       
        public string SiteWeb { get; set; }
       
        public int? Numbureau { get; set; }
        public int? NumFax { get; set; }
        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }

        public string EmailPersAContact { get; set; }
        public virtual IList<Document> Documents { get; set; }
        public virtual IList<Stock> Stocks { get; set; }


    }
}
