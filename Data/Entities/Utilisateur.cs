using Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
  public  class Utilisateur
    {

        public int Id { get; set; }
        public String Nom { get; set; }

        public String Prenom { get; set; }
        public int? Telephone { get; set; }
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }

        public Civility Civility { get; set; }

        [RegularExpression(@"^[0-9]{8}[A-Za-z]$", ErrorMessage = "Must be a In this format 12345678X.")]
        [StringLength(9, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Identifiant_fiscale { get; set; }
        public int NumMobile { get; set; }
        public String Adresse { get; set; }
    }
}
