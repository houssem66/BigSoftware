using Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class FournisseurModel
    {
        public string NomPersAContact { get; set; }
        [Required]
        public string RaisonSocial { get; set; }
        [Required]
        public string PrenomPersAContact { get; set; }

        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public FormeJuridique FormeJuridique { get; set; }
        public string SiteWeb { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string PhoneBureau { get; set; }
        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }

        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string NumMobile { get; set; }
        public Civility Civility { get; set; }

        [Required]
        public Gouvernorats Gouvernorats { get; set; }
        [Required]
        public String Adresse { get; set; }
        public string IdGrossiste { get; set; }
    }
}
