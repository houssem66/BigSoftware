using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Data.Entities
{
    public class BonCommandeClient
    {
        [Key]
        public int Id { get; set; }
        public Decimal Prix { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Grossiste Grossiste { get; set; }
        public string GrossisteId { get; set; }
        public virtual ICollection<DetailsCommandeClient> DetailsCommandes { get; set; }

    }
}
