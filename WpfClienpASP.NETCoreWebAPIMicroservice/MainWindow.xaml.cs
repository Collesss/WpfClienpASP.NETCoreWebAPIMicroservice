using DBMetricsManager;
using EntitiesMetricsManager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace WpfClienpASP.NETCoreWebAPIMicroservice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public SeriesCollection SeriesCollection { get; set;}

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(DateTime.Now.AddDays(0), 10),
                        new DateTimePoint(DateTime.Now.AddDays(1), 20),
                        new DateTimePoint(DateTime.Now.AddDays(2), 30),
                        new DateTimePoint(DateTime.Now.AddDays(3), 40),
                        new DateTimePoint(DateTime.Now.AddDays(4), 50),
                        new DateTimePoint(DateTime.Now.AddDays(5), 40),
                        new DateTimePoint(DateTime.Now.AddDays(6), 60),
                        new DateTimePoint(DateTime.Now.AddDays(7), 20),
                        new DateTimePoint(DateTime.Now.AddDays(10), 100)
                    }
                }
            };

            DataContext = this;

            _serviceProvider = serviceProvider;
        }

        public async void UpdateAgentsList_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click update agents list");

            UpdateAgentsList.IsEnabled = false;

            using(IServiceScope scope = _serviceProvider.CreateScope())
            {
                IRepositoryAgents<MetricAgent> repositoryAgents = scope.ServiceProvider.GetRequiredService<IRepositoryAgents<MetricAgent>>();

                AgentsList.ItemsSource = (await repositoryAgents.GetAll()).Select(ma => $"{ma.Id}: {ma.AddressAgent.Host}");
            }

            UpdateAgentsList.IsEnabled = true;
        }
    }
}
