using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsCpu : RepositoryMetricAgents<CpuMetricAgent>
    {
        protected override string BaseRoute => $"{base.BaseRoute}CpuMetric";
        public RepositoryMetricAgentsCpu(IHttpClientFactory httpClientFactory, Uri addressServer) :
            base(httpClientFactory, addressServer) { }
    }
}
