using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsNetwork : RepositoryMetricAgents<NetworkMetricAgent>
    {
        protected override string BaseRoute => $"{base.BaseRoute}NetworkMetric";
        public RepositoryMetricAgentsNetwork(IHttpClientFactory httpClientFactory, Uri addressServer) :
            base(httpClientFactory, addressServer) { }
    }
}
