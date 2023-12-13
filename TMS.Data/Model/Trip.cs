using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class Trip
    {
        public int TripID { get; set; }
        public int OrderID { get; set; }
        public int CarrierID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        // Add other properties as needed
    }
}
