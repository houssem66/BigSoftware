using Data.Entities.Enum;
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
    
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDate { get; set; }
        public Civility Civility { get; set; }


        public int? NumMobile { get; set; }
        public String Adresse { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }
        public Gouvernorats Gouvernorats { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"([0-9]{4})", ErrorMessage = "Must be a Number.")]
        [StringLength(4, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string CodePostale { get; set; }
        public IFormFile Image { get; set; }
    }
}
