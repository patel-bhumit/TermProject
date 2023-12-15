using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    namespace DataLayer.Model
    {
        [Table("Order")]
        public class Order
        {
            [Key]
            public int OrderID { get; set; }

            public string ClientName { get; set; }

            public int JobType { get; set; }

            public int Quantity { get; set; }

            public string Origin { get; set; }

            public string Destination { get; set; }

            public int VanType { get; set; }

            public string OrderStatus { get; set; }
            public DateTime OrderDate { get; set; }

            // add a entity to give the possible time of delivery
            public DateTime? DeliveryDate { get; set; }

            public string? Invoice { get; set; }

            [ForeignKey("Carrier")]
            public int? cID { get; set; }

            public virtual Carrier Carrier { get; set; }

        }
    }

}