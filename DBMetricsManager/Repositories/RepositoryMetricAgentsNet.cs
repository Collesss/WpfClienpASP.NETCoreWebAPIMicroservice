using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsNet : RepositoryMetricAgents<NetMetricAgent>
    {
        protected override string BaseRoute => $"{base.BaseRoute}NetMetric";
        public RepositoryMetricAgentsNet(IHttpClientFactory httpClientFactory, Uri addressServer) :
            base(httpClientFactory, addressServer) { }
    }
}
