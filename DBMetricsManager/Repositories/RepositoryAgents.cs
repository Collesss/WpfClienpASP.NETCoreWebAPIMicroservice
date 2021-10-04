using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBMetricsManager
{
    public class RepositoryAgents<TEntity> : IRepositoryAgents<TEntity> where TEntity : BaseEntity
    {
        private IHttpClientFactory _httpClientFactory;
        private Uri _addressServer;

        public RepositoryAgents(IHttpClientFactory httpClientFactory, Uri addressServer)
        {
            _httpClientFactory = httpClientFactory;
            _addressServer = addressServer;
        }

        async Task<IEnumerable<TEntity>> IRepositoryAgents<TEntity>.GetAll()
        {
            UriBuilder uriBuilder = new UriBuilder(_addressServer);
            uriBuilder.Path = "api/Agents";

            HttpResponseMessage httpResponse = await _httpClientFactory.CreateClient("MetricAgent").SendAsync(new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri));

            return httpResponse.IsSuccessStatusCode ?
                 await JsonSerializer.DeserializeAsync<TEntity[]>(await httpResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions(JsonSerializerDefaults.Web)) :
                 new TEntity[0];
        }
    }
}
