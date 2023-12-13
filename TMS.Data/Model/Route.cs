using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class Route
    {
        public int RouteID { get; set; }
        public string StartCity { get; set; }
        public string EndCity { get; set; }
        public decimal Distance { get; set; }
    }
}
