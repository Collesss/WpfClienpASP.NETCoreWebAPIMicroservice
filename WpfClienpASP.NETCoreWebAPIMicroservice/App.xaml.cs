using DBMetricsManager;
using EntitiesMetricsManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfClienpASP.NETCoreWebAPIMicroservice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; }

        static App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddHttpClient("MetricAgent")
                .AddTransientHttpErrorPolicy(p =>
                p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));

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

        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow(Services).Show();

            base.OnStartup(e);
        }
    }
}
