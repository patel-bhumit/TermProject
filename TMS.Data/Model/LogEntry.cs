using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Model
{
    public class LogEntry
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public DateTime LogTime { get; set; }
        public string LogMessage { get; set; }
    }
}
