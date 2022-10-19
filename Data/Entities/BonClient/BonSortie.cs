﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Entities
{
   public class BonSortie
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Decimal PrixTotaleTTc { get; set; }
        public Decimal PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public  Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsBonSortie> DetailsBonSorties { get; set; }

    }
}
