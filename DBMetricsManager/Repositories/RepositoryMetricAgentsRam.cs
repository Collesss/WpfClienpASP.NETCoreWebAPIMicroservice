using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsRam : RepositoryMetricAgents<RamMetricAgent>
    {
        protected override string BaseRoute => $"{base.BaseRoute}RamMetric";
        public RepositoryMetricAgentsRam(IHttpClientFactory httpClientFactory, Uri addressServer) :
            base(httpClientFactory, addressServer) { }
    }
}
