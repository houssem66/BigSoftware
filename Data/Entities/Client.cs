using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Entities.Enum;


namespace Data.Entities
{
    public class Client : Utilisateur
    {
        public TypeClient TypeClient { get; set; }
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(8, ErrorMessage = "The {0}  cannot exceed {1} characters. ")]
        public string Cin { get; set; }
    }
}
