using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMetricsManager
{
    public interface IRepositoryMetricAgents<TEntity> where TEntity : BaseMetricAgent
    {
        public Task<IEnumerable<TEntity>> GetMetricFromAgent(int id, DateTime from, DateTime to);
        public Task<IEnumerable<TEntity>> GetMetricFromAgents(DateTime from, DateTime to);
    }
}
