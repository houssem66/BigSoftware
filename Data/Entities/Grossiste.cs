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
        public string PersAContact { get; set; }
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
        public Gouvernorats Gouvernorats { get; set; }
        public int Numbureau { get; set; }
    }
}
