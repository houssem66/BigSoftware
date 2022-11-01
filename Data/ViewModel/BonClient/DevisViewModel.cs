using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public  class DevisViewModel
    {
        public int ClientId { get; set; }
        public Decimal? PrixTotaleTTc { get; set; }
        public Decimal? PrixTotaleHt { get; set; }
        public DateTime Date { get; set; }
        public string GrossisteId { get; set; }
        public IList<DetailsDevisModel> DetailsDevisModels { get; set; }
    }
}
