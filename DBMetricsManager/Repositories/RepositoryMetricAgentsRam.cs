using AutoMapper;
using Entities;
using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsRam : RepositoryMetricAgents<RamMetricAgent, RamMetric>
    {
        protected override string BaseRoute => $"{base.BaseRoute}RamMetric";
        public RepositoryMetricAgentsRam(IRepositoryAgents<MetricAgent> repository, IMapper mapper, IHttpClientFactory httpClientFactory) :
            base(repository, mapper, httpClientFactory)
        { }
    }
}
