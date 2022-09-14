using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ChangeDocumentsModel
    {
        public string id { get; set; }
        public IFormFile Documents { get; set; }
     
    }
}
