using DataLayer.Model.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Model
{
    [Table("Invoice")]
    public class Invoice
    {
            [Key]
            public int InvoiceID { get; set; }

            public int OrderID { get; set; }

            public string ClientName { get; set; }

            public double TotalAmount { get; set; }

            public DateTime InvoiceDate { get; set; }

            // You can add more properties as needed

            // Navigation properties
            public Order Order { get; set; }

        }
}
