using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Entities.Enum;


namespace Data.Entities
{
    public class Client
    {[Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public String Nom { get; set; }
        [Required, MaxLength(50)]
        public String Prenom { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string PhoneBureau { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Civility Civility { get; set; }

        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string NumMobile { get; set; }
        public Gouvernorats Gouvernorats { get; set; }
        public String Adresse { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }
        public TypeClient TypeClient { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Cin { get; set; }
        public Grossiste Grossiste { get; set; }
        public string IdGrossiste { get; set; }
        public virtual ICollection<BonLivraisonClient> BonLivraisonClients { get; set; }
        public virtual ICollection<BonCommandeClient> BonCommandeClients { get; set; }
        public virtual ICollection<BonSortie> BonSorties { get; set; }
        public virtual ICollection<Devis> Devis { get; set; }
        public virtual ICollection<FactureClient> FactureClients { get; set; }

    }
}
