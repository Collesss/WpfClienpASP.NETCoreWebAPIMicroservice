using DBMetricsManager;
using EntitiesMetricsManager;
using Microsoft.Extensions.DependencyInjection;
using System;
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


namespace WpfClienpASP.NETCoreWebAPIMicroservice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        public async void UpdateAgentsList_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click update agents list");

            UpdateAgentsList.IsEnabled = false;

            using(IServiceScope scope = _serviceProvider.CreateScope())
            {
                IRepositoryAgents<MetricAgent> repositoryAgents = scope.ServiceProvider.GetRequiredService<IRepositoryAgents<MetricAgent>>();

                AgentsList.ItemsSource = await repositoryAgents.GetAll();
            }

            UpdateAgentsList.IsEnabled = true;
        }
    }
}
