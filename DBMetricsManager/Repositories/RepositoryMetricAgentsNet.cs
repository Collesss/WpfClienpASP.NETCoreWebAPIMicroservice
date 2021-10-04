using AutoMapper;
using Entities;
using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsNet : RepositoryMetricAgents<NetMetricAgent, NetMetric>
    {
        protected override string BaseRoute => $"{base.BaseRoute}NetMetric";
        public RepositoryMetricAgentsNet(IRepositoryAgents<MetricAgent> repository, IMapper mapper, IHttpClientFactory httpClientFactory) :
            base(repository, mapper, httpClientFactory)
        { }
    }
}
