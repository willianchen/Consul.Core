using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Core
{
    public interface IConsulClient
    {
        #region KVStore
        Task<bool> KVAcquireAsync(KVPair p);

        Task<bool> KVAcquireAsync(KVPair p, WriteOptions q);

        Task<bool> KVCasAsync(KVPair p);

        Task<bool> KVCasAsync(KVPair p, WriteOptions q);

        Task<bool> KVDeleteAsync(string key);

        Task<bool> KVDeleteAsync(string key, WriteOptions q);

        Task<bool> KVDeleteCasAsync(KVPair p);

        Task<bool> KVDeleteCasAsync(KVPair p, WriteOptions q);

        Task<bool> KVDeleteTreeAsync(string prefix);

        Task<bool> KVDeleteTreeAsync(string prefix, WriteOptions q);

        Task<string> KVGetValueAsync(string key);

        Task<T> KVGetAsync<T>(string key) where T : class;

        Task<KVPair> KVGetAsync(string key);

        Task<T> KVGetAsync<T>(string key, QueryOptions q) where T : class;

        Task<string> KVGetValueAsync(string key, QueryOptions q);

        Task<KVPair> KVGetAsync(string key, QueryOptions q);

        Task<string[]> KVKeysAsync(string prefix);

        Task<string[]> KVKeysAsync(string prefix, string separator);

        Task<string[]> KVKeysAsync(string prefix, string separator, QueryOptions q);

        Task<IEnumerable<T>>  KVListAsync<T>(string prefix) where T : class;

        Task<KVPair[]> KVListAsync(string prefix);

        Task<KVPair[]> KVListAsync(string prefix, QueryOptions q);

        Task<bool> KVPutAsync(string key, string value);

        Task<bool> KVPutAsync<T>(string key, T value) where T : class;

        Task<bool> KVPutAsync(KVPair p);

        Task<bool> KVPutAsync(KVPair p, WriteOptions q);

        Task<bool> KVReleaseAsync(KVPair p);

        Task<bool> KVReleaseAsync(KVPair p, WriteOptions q);

        #endregion KVStore

        #region Health

        Task<HealthCheck[]> HealthChecks(string service);
        Task<HealthCheck[]> HealthChecks(string service, QueryOptions q);
        Task<HealthCheck[]> HealthNode(string node);
        Task<HealthCheck[]> HealthNode(string node, QueryOptions q);
        Task<ServiceEntry[]> HealthService(string service);
        Task<ServiceEntry[]> HealthService(string service, string tag);
        Task<ServiceEntry[]> HealthService(string service, string tag, bool passingOnly);
        Task<ServiceEntry[]> HealthService(string service, string tag, bool passingOnly, QueryOptions q);
        Task<HealthCheck[]> HealthState(HealthStatus status);
        Task<HealthCheck[]> HealthState(HealthStatus status, QueryOptions q);

        #endregion

        #region Catalog

        Task<string[]> CatalogDatacenters();
        Task<bool> CatalogDeregister(CatalogDeregistration reg);
        Task<bool> CatalogDeregister(CatalogDeregistration reg, WriteOptions q);
        Task<CatalogNode> CatalogNode(string node);
        Task<CatalogNode> CatalogNode(string node, QueryOptions q);
        Task<Node[]> CatalogNodes();
        Task<Node[]> CatalogNodes(QueryOptions q);
        Task<bool> CatalogRegister(CatalogRegistration reg);
        Task<bool> CatalogRegister(CatalogRegistration reg, WriteOptions q);
        Task<CatalogService[]> CatalogService(string service);
        Task<CatalogService[]> CatalogService(string service, string tag);
        Task<CatalogService[]> CatalogService(string service, string tag, QueryOptions q);
        Task<Dictionary<string, string[]>> CatalogServices();
        Task<Dictionary<string, string[]>> CatalogServices(QueryOptions q);
        #endregion

    }


}
