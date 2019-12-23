using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Report : Entity
    {
        public DateTime ReportTime { get; set; } = DateTime.Now;
    }
}
