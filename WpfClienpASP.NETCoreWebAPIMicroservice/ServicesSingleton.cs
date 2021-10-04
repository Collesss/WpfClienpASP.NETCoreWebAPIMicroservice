using DBMetricsManager;
using EntitiesMetricsManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfClienpASP.NETCoreWebAPIMicroservice
{
    public static class ServicesSingleton
    {
        public static IServiceProvider Services { get; }
        static ServicesSingleton()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddHttpClient();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            services.AddSingleton(configuration);

            services.AddSingleton(new Uri(configuration["AddressServer"]));

            services.AddScoped<IRepositoryAgents<MetricAgent>, RepositoryAgents<MetricAgent>>();
            
            services.AddScoped<IRepositoryMetricAgents<CpuMetricAgent>, RepositoryMetricAgentsCpu>();
            services.AddScoped<IRepositoryMetricAgents<HardDriveMetricAgent>, RepositoryMetricAgentsHardDrive>();
            services.AddScoped<IRepositoryMetricAgents<NetMetricAgent>, RepositoryMetricAgentsNet>();
            services.AddScoped<IRepositoryMetricAgents<NetworkMetricAgent>, RepositoryMetricAgentsNetwork>();
            services.AddScoped<IRepositoryMetricAgents<RamMetricAgent>, RepositoryMetricAgentsRam>();

            Services = services.BuildServiceProvider();
        }

    }
}
