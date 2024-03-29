﻿using Data.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
  public  class Utilisateur :  IdentityUser
    {   [Required,MaxLength(50)]
        public String Nom { get; set; }
        [Required, MaxLength(50)]
        public String Prenom { get; set; }
       
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public Civility Civility { get; set; }

        public Gouvernorats Gouvernorats { get; set; }
        public int? NumMobile { get; set; }
        public String Adresse { get; set; }
        [RegularExpression(@"([0-9]{4})", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }

        public string Image { get; set; }

    }
}
