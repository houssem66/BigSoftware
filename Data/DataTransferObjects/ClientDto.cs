using Data.Entities;
using Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataTransferObjects
{
  public  class ClientDtoUpdate
    {
     
        public int Id { get; set; }
       
        public String Nom { get; set; }
    
        public String Prenom { get; set; }

     
        public DateTime BirthDate { get; set; }
      
        public string PhoneBureau { get; set; }
    
        public string Email { get; set; }
        public Civility Civility { get; set; }

      
        public string Identifiant_fiscale { get; set; }
     
        public string NumMobile { get; set; }
        public Gouvernorats Gouvernorats { get; set; }
        public String Adresse { get; set; }
      
        public string CodePostale { get; set; }
        public TypeClient TypeClient { get; set; }
      
        public string Cin { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string IdGrossiste { get; set; }
      

    }
}
