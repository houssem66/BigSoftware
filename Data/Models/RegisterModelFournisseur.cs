using Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
  public  class RegisterModelFournisseur
    {//User Attribut
        [Required, MaxLength(50)]
        public String Nom { get; set; }
        [Required, MaxLength(50)]
        public String Prenom { get; set; }
        public string Telephone { get; set; }
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
      

        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }
        public int NumMobile { get; set; }
        public String Adresse { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //Fournisseur Attribut
        [DefaultValue(false)]
        public Boolean Verified { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(20, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Rib { get; set; }
        // ajouté le 11/06/2021
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }
        public string SiteWeb { get; set; }
        public int Numbureau { get; set; }
    }
}
