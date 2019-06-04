using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class ParaLog
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public int SupervisorID { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }

        public string Description { get; set; }
        public TimeSpan TimeAccrued { get; set; }

        public string Status { get; set; }
    }
}
