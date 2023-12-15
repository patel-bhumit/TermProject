using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("Route")]
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [ForeignKey("Carrier")]
        public int cID { get; set; }

        public string CarrierName { get; set; }

        public string DestinationCity { get; set; }

        // Navigation property
        public virtual Carrier Carrier { get; set; }
    }
}
