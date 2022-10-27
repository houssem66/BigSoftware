using Data.Entities.Enum;
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
        [Required]
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
        [Required]
        public int? Numbureau { get; set; }
        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }

        public int? NumFax { get; set; }
        [Required]
        public Gouvernorats Gouvernorats { get; set; }
        [Required]
        public String Adresse { get; set; }
        public string IdGrossiste { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public virtual ICollection<BonDeCommandeFournisseur> BonDeCommandes{ get; set; }
        public virtual ICollection<BonDeReceptionFournisseur> BonDeReceptions{ get; set; }
    }
}
