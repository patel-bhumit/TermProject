using DataLayer.Model.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("Carrier")]
    public class Carrier
    {
        [Key]
        public int cID { get; set; }

        public string cName { get; set; }

        public string dCity { get; set; }
        public int FTLA { get; set; }
        public int LTLA { get; set; }
        public double FTLARate { get; set; }
        public double LTLRate { get; set; }
        public double reefCharge { get; set; }

        // Add a foreign key property
        [ForeignKey("City")]
        public int CityId { get; set; }

        // Navigation property
        public virtual ICollection<Order> Orders { get; set; }

    }
}
