using DataLayer.Model.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("Trip")]
    public class Trip
    {
        [Key]
        public int TripID { get; set; }

        public string ClientName { get; set; }

        public int TripNumber { get; set; }

        // Foreign key to Order
        public int OrderID { get; set; }

        // Foreign key to Carrier
        public int CarrierID { get; set; }

        // Additional properties
        public string CarrierName { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string OrderStatus { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Carrier Carrier { get; set; }

        // Other properties as needed
    }
}

