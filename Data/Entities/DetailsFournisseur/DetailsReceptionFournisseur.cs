﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class DetailsReceptionFournisseur
    {
        public int IdProduit { get; set; }
        public int IdBonReception { get; set; }
        public Decimal Quantite { get; set; }
        public Decimal Montant { get; set; }
        public Produit Produit   { get; set; }
        public BonDeReceptionFournisseur BonDeRéception { get; set; }
    }
}