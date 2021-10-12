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


        public SeriesCollection SeriesCollection { get; set; }

        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Random random = new Random();

            int cpu = 50;

            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Cpu Load",
                    MinHeight = 0,
                    MaxHeight = 100,
                    Values = new ChartValues<DateTimePoint>(Enumerable.Range(0, 1000).Select(i =>
                    new DateTimePoint(
                        DateTime.Now.AddSeconds(i),
                        cpu = Math.Clamp(cpu + random.Next(-40, 40), 0, 100))
                        ))
                }
            };

            XFormatter = data =>
                new DateTime((long)data).ToString();

            YFormatter = data =>
                String.Format("{0,2:f}%", data);

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
