using AutoMapper;
using Entities;
using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsHardDrive : RepositoryMetricAgents<HardDriveMetricAgent, HardDriveMetric>
    {
        protected override string BaseRoute => $"{base.BaseRoute}HardDriveMetric";
        public RepositoryMetricAgentsHardDrive(IRepositoryAgents<MetricAgent> repository, IMapper mapper, IHttpClientFactory httpClientFactory) :
            base(repository, mapper, httpClientFactory)
        { }
    }
}
