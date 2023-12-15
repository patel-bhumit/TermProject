// LogEntry.cs

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    [Table("LogEntries")]
    public class LogEntry
    {
        [Key]
        public int LogId { get; set; }

        public DateTime Timestamp { get; set; }

        public string LogLevel { get; set; }

        public string Message { get; set; }
    }
}