using EntitiesMetricsManager;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMetricsManager
{
    public class RepositoryAgents<TEntity> : IRepositoryAgents<TEntity> where TEntity : BaseEntity
    {
        public RepositoryAgents()
        {

        }

        IEnumerable<TEntity> IRepositoryAgents<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
