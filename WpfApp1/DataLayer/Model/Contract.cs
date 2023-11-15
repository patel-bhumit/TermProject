using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("Contract")]
    public class Contract
    {
        [Key]
        public string Client_Name { get; set; }


        public int Job_Type { get; set; }

        public int Quantity { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public int Van_Type { get; set; }
    }
}
