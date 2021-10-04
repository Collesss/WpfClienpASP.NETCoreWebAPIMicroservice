using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DBMetricsManager
{
    public class RepositoryMetricAgentsHardDrive : RepositoryMetricAgents<HardDriveMetricAgent>
    {
        protected override string BaseRoute => $"{base.BaseRoute}HardDriveMetric";
        public RepositoryMetricAgentsHardDrive(IHttpClientFactory httpClientFactory, Uri addressServer) :
            base(httpClientFactory, addressServer) { }
    }
}
