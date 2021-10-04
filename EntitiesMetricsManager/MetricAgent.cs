using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiesMetricsManager
{
    public class MetricAgent : BaseEntity
    {
        public Uri AddressAgent { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
