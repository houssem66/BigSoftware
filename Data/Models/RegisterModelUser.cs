﻿using Data.Entities.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
  public  class RegisterModelUser
    {
        [Required, MaxLength(50)]
        public String Nom { get; set; }
        [Required, MaxLength(50)]   
        public String Prenom { get; set; }
        public string Telephone { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDate { get; set; }
        public Civility Civility { get; set; }

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
        public IFormFile Document { get; set; }
    }
}
