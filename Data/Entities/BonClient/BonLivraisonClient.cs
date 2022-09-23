﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Entities
{
    public class BonLivraisonClient
    {[Key]
        public int Id { get; set; }
        public Decimal Prix { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<DetailsLivraisonClient> DetailsLivraisons { get; set; }
    }
}
