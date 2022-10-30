using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class PasswordModel
    {
        public string id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
