using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class RateFeeTable
    {
        public int RateID { get; set; }
        public string RateName { get; set; }
        public decimal Amount { get; set; }
    }
}
