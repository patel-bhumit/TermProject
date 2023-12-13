using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string Status { get; set; }
        // Add other properties as needed
    }
}
