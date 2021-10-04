using AutoMapper;
using Entities;
using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsCpu : RepositoryMetricAgents<CpuMetricAgent, CpuMetric>
    {
        protected override string BaseRoute => $"{base.BaseRoute}CpuMetric";
        public RepositoryMetricAgentsCpu(IRepositoryAgents<MetricAgent> repository, IMapper mapper, IHttpClientFactory httpClientFactory) : 
            base(repository, mapper, httpClientFactory) { }
    }
}
