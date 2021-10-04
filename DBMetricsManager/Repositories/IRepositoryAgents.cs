using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMetricsManager
{
    public interface IRepositoryAgents<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
