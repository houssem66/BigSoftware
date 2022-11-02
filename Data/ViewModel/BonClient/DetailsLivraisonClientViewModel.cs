﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DetailsLivraisonClientViewModel
    {
        public int IdProduit { get; set; }
        public int IdBonLivraison { get; set; }
        public Decimal? Quantite { get; set; }
        public Decimal? MontantTTc { get; set; }
        public Decimal? MontantHt { get; set; }
    }
}