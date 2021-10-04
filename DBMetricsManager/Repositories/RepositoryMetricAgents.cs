using EntitiesMetricsManager;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBMetricsManager
{
    public abstract class RepositoryMetricAgents<TEntity> : IRepositoryMetricAgents<TEntity> where TEntity : BaseMetricAgent
    {
        protected virtual string BaseRoute => "api/";

        private IHttpClientFactory _httpClientFactory;
        private Uri _addressServer;

        protected RepositoryMetricAgents(IHttpClientFactory httpClientFactory, Uri addressServer)
        {
            _httpClientFactory = httpClientFactory;
            _addressServer = addressServer;
        }

        /*
        private HttpRequestMessage GetRequestMessage(MetricAgent metricAgent, DateTime from, DateTime to)
        {
            UriBuilder uriBuilder = new UriBuilder(metricAgent.AddressAgent);

            RouteEntityAttribute routeEntityAttribute = (RouteEntityAttribute)Attribute.GetCustomAttribute(typeof(TEntity), typeof(RouteEntityAttribute));

            uriBuilder.Path = $"api/{routeEntityAttribute.GetRoute(typeof(TEntity).Name)}/from/{from:yyyy-MM-ddTHH:mm:ss.FFFFFFF}/to/{to:yyyy-MM-ddTHH:mm:ss.FFFFFFF}";

            return new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        }
        */

        private async Task<HttpResponseMessage> GetHttpResponseMessage(DateTime from, DateTime to, int idAgent = 0)
        {
            UriBuilder uriBuilder = new UriBuilder(_addressServer);

            //RouteEntityAttribute routeEntityAttribute = (RouteEntityAttribute)Attribute.GetCustomAttribute(typeof(TEntity), typeof(RouteEntityAttribute));
            //uriBuilder.Path = $"api/{routeEntityAttribute.GetRoute(typeof(TEntity).Name)}/from/{from:yyyy-MM-ddTHH:mm:ss.FFFFFFF}/to/{to:yyyy-MM-ddTHH:mm:ss.FFFFFFF}";

            uriBuilder.Path = $"{BaseRoute}{(idAgent != 0 ? $"agent/{idAgent}" : "")}/from/{from}/to/{to}";

            return await _httpClientFactory.CreateClient("MetricAgent").SendAsync(new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri));
        }

        async Task<IEnumerable<TEntity>> IRepositoryMetricAgents<TEntity>.GetMetricFromAgent(int id, DateTime from, DateTime to)
        {
            HttpResponseMessage httpResponse = await GetHttpResponseMessage(from, to, id);

            if (httpResponse.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<TEntity[]>(await httpResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return new TEntity[0];
        }

        async Task<IEnumerable<TEntity>> IRepositoryMetricAgents<TEntity>.GetMetricFromAgents(DateTime from, DateTime to)
        {
            HttpResponseMessage httpResponse = await GetHttpResponseMessage(from, to);

            if (httpResponse.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<TEntity[]>(await httpResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return new TEntity[0];
        }
    }
}
