using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string ClientName { get; set; }

        public int JobType { get; set; }

        public int Quantity { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public int VanType { get; set; }


    }
}