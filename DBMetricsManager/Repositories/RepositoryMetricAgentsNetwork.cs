using AutoMapper;
using Entities;
using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsNetwork : RepositoryMetricAgents<NetworkMetricAgent, NetworkMetric>
    {
        protected override string BaseRoute => $"{base.BaseRoute}NetworkMetric";
        public RepositoryMetricAgentsNetwork(IRepositoryAgents<MetricAgent> repository, IMapper mapper, IHttpClientFactory httpClientFactory) :
            base(repository, mapper, httpClientFactory)
        { }
    }
}
