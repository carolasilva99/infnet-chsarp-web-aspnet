using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Models
{
    public class Token
    {
        public string BearerToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
