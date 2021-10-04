using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesMetricsManager
{
    public class BaseMetricAgent : BaseEntity
    {
        public int AgentId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
