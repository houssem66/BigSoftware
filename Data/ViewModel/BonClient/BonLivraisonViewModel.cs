using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
  public  class BonLivraisonViewModel
    {
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string GrossisteId { get; set; }
        public IList<DetailsLivraisonClientViewModel> DetailsLivraisonsModel { get; set; }

    }
}
