using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class CarrierData
    {
        public int CarrierID { get; set; }
        public string CarrierName { get; set; }
        public string DestinationCity { get; set; }
        public int FTLA { get; set; }
        public int LTLA { get; set; }
        public decimal FTLRate { get; set; }
        public decimal LTLRate { get; set; }
        public decimal ReefCharge { get; set; }
    }
}
