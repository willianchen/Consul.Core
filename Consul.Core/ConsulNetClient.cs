using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CML.Lib.Json;
using Consul;

namespace Consul.Core
{
    public class ConsulNetClient : IConsulClient, IDisposable
    {
        private ConsulOption _consulOption;
        public ConsulNetClient(ConsulOption consulOption)
        {
            //EnsureUtil.NotNull(consulOption, "consulOption");
            _consulOption = consulOption;
        }

        private ConsulClient _consulClient
        {
            get
            {
                Action<ConsulClientConfiguration> cfgAction = (cfg) =>
                {
                    cfg.Address = new Uri(_consulOption.Host);
                    cfg.Datacenter = _consulOption.DataCenter;
                    cfg.Token = _consulOption.Token;
                    cfg.WaitTime = _consulOption.WaitTime;
                };
                //Action<HttpClient> cfgHttpAction = (client) => { _consulOption.TimeOut?client.Timeout = _consulOption.TimeOut; };
                return new ConsulClient(cfgAction);
            }
        }

        #region Catalog 

        public async Task<string[]> CatalogDatacenters()
        {
            var result = await _consulClient.Catalog.Datacenters();
            return result.Response;
        }

        public async Task<bool> CatalogDeregister(CatalogDeregistration reg)
        {
            var result = await _consulClient.Catalog.Deregister(reg);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> CatalogDeregister(CatalogDeregistration reg, WriteOptions q)
        {
            var result = await _consulClient.Catalog.Deregister(reg, q);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<CatalogNode> CatalogNode(string node)
        {
            var result = await _consulClient.Catalog.Node(node);
            return result.Response;
        }

        public async Task<CatalogNode> CatalogNode(string node, QueryOptions q)
        {
            var result = await _consulClient.Catalog.Node(node, q);
            return result.Response;
        }

        public async Task<Node[]> CatalogNodes()
        {
            var result = await _consulClient.Catalog.Nodes();
            return result.Response;
        }

        public async Task<Node[]> CatalogNodes(QueryOptions q)
        {
            var result = await _consulClient.Catalog.Nodes(q);
            return result.Response;
        }

        public async Task<bool> CatalogRegister(CatalogRegistration reg)
        {
            var result = await _consulClient.Catalog.Register(reg);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> CatalogRegister(CatalogRegistration reg, WriteOptions q)
        {
            var result = await _consulClient.Catalog.Register(reg, q);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<CatalogService[]> CatalogService(string service)
        {
            var result = await _consulClient.Catalog.Service(service);
            return result.Response;
        }

        public async Task<CatalogService[]> CatalogService(string service, string tag)
        {
            var result = await _consulClient.Catalog.Service(service, tag);
            return result.Response;
        }

        public async Task<CatalogService[]> CatalogService(string service, string tag, QueryOptions q)
        {
            var result = await _consulClient.Catalog.Service(service, tag, q);
            return result.Response;
        }

        public async Task<Dictionary<string, string[]>> CatalogServices()
        {
            var result = await _consulClient.Catalog.Services();
            return result.Response;
        }

        public async Task<Dictionary<string, string[]>> CatalogServices(QueryOptions q)
        {
            var result = await _consulClient.Catalog.Services(q);
            return result.Response;
        }

        #endregion


        public async Task<HealthCheck[]> HealthChecks(string service)
        {
            var result = await _consulClient.Health.Checks(service);
            return result.Response;
        }

        public async Task<HealthCheck[]> HealthChecks(string service, QueryOptions q)
        {
            var result = await _consulClient.Health.Checks(service, q);
            return result.Response;
        }

        public async Task<HealthCheck[]> HealthNode(string node)
        {
            var result = await _consulClient.Health.Node(node);
            return result.Response;
        }

        public async Task<HealthCheck[]> HealthNode(string node, QueryOptions q)
        {
            var result = await _consulClient.Health.Node(node, q);
            return result.Response;
        }

        public async Task<ServiceEntry[]> HealthService(string service)
        {
            var result = await _consulClient.Health.Service(service);
            return result.Response;
        }

        public async Task<ServiceEntry[]> HealthService(string service, string tag)
        {
            var result = await _consulClient.Health.Service(service, tag);
            return result.Response;
        }

        public async Task<ServiceEntry[]> HealthService(string service, string tag, bool passingOnly)
        {
            var result = await _consulClient.Health.Service(service, tag, passingOnly);
            return result.Response;
        }

        public async Task<ServiceEntry[]> HealthService(string service, string tag, bool passingOnly, QueryOptions q)
        {
            var result = await _consulClient.Health.Service(service, tag, passingOnly, q);
            return result.Response;
        }

        public async Task<HealthCheck[]> HealthState(HealthStatus status)
        {
            var result = await _consulClient.Health.State(status);
            return result.Response;
        }

        public async Task<HealthCheck[]> HealthState(HealthStatus status, QueryOptions q)
        {
            var result = await _consulClient.Health.State(status, q);
            return result.Response;
        }

        #region KVStore
        public async Task<bool> KVAcquireAsync(KVPair p)
        {
            var result = await _consulClient.KV.Acquire(p);
            return result.Response;
        }

        public async Task<bool> KVAcquireAsync(KVPair p, WriteOptions q)
        {
            var result = await _consulClient.KV.Acquire(p, q);
            return result.Response;
        }

        public async Task<bool> KVCasAsync(KVPair p)
        {
            var result = await _consulClient.KV.CAS(p);
            return result.Response;
        }

        public async Task<bool> KVCasAsync(KVPair p, WriteOptions q)
        {
            var result = await _consulClient.KV.CAS(p, q);
            return result.Response;
        }

        public async Task<bool> KVDeleteAsync(string key)
        {
            var result = await _consulClient.KV.Delete(key);
            return result.Response;
        }

        public async Task<bool> KVDeleteAsync(string key, WriteOptions q)
        {
            var result = await _consulClient.KV.Delete(key, q);
            return result.Response;
        }

        public async Task<bool> KVDeleteCasAsync(KVPair p)
        {
            var result = await _consulClient.KV.DeleteCAS(p);
            return result.Response;
        }

        public async Task<bool> KVDeleteCasAsync(KVPair p, WriteOptions q)
        {
            var result = await _consulClient.KV.DeleteCAS(p, q);
            return result.Response;
        }

        public async Task<bool> KVDeleteTreeAsync(string prefix)
        {
            var result = await _consulClient.KV.DeleteTree(prefix);
            return result.Response;
        }

        public async Task<bool> KVDeleteTreeAsync(string prefix, WriteOptions q)
        {
            var result = await _consulClient.KV.DeleteTree(prefix, q);
            return result.Response;
        }

        public async Task<KVPair> KVGetAsync(string key)
        {
            var result = await _consulClient.KV.Get(key);
            return result.Response;
        }

        public async Task<KVPair> KVGetAsync(string key, QueryOptions q)
        {
            var result = await _consulClient.KV.Get(key, q);
            return result.Response;
        }

        public async Task<T> KVGetAsync<T>(string key) where T : class
        {
            var obj = await KVGetValueAsync(key);
            return new NewtonsoftJsonSerializer().GetObjByJson<T>(obj);
        }

        public async Task<T> KVGetAsync<T>(string key, QueryOptions q) where T : class
        {
            var obj = await KVGetValueAsync(key, q);
            return new NewtonsoftJsonSerializer().GetObjByJson<T>(obj);
        }

        public async Task<string> KVGetValueAsync(string key)
        {
            var obj = await KVGetAsync(key);
            return GetString(obj?.Value);
        }

        public async Task<string> KVGetValueAsync(string key, QueryOptions q)
        {
            var obj = await KVGetAsync(key, q);
            return GetString(obj?.Value);
        }

        public async Task<string[]> KVKeysAsync(string prefix)
        {
            var result = await _consulClient.KV.Keys(prefix);
            return result.Response;
        }


        public async Task<string[]> KVKeysAsync(string prefix, string separator)
        {
            var result = await _consulClient.KV.Keys(prefix, separator);
            return result.Response;
        }

        public async Task<string[]> KVKeysAsync(string prefix, string separator, QueryOptions q)
        {
            var result = await _consulClient.KV.Keys(prefix, separator, q);
            return result.Response;
        }

        public async Task<KVPair[]> KVListAsync(string prefix)
        {
            var result = await _consulClient.KV.List(prefix);
            return result.Response;
        }

        public async Task<KVPair[]> KVListAsync(string prefix, QueryOptions q)
        {
            var result = await _consulClient.KV.List(prefix, q);
            return result.Response;
        }

        public async Task<IEnumerable<T>> KVListAsync<T>(string prefix) where T : class
        {
            List<T> list = new List<T>();
            var kvList = await KVListAsync(prefix);
            if (kvList != null)
                foreach (var t in kvList?.ToList())
                {
                    list.Add(new NewtonsoftJsonSerializer().GetObjByJson<T>(GetString(t.Value)));
                }
            return list;
        }

        public  Task<bool> KVPutAsync(string key, string value)
        {
            KVPair kv = new KVPair(key)
            {
                Value = GetByte(value)
            };
            return KVPutAsync(kv);
        }

        public  Task<bool> KVPutAsync<T>(string key, T value) where T : class
        {
            KVPair kv = new KVPair(key)
            {
                Value = GetByte(new NewtonsoftJsonSerializer().GetJsonByObj(value))
            };
            return KVPutAsync(kv);
        }

        public async Task<bool> KVPutAsync(KVPair p)
        {
            var result = await _consulClient.KV.Put(p);
            return result.Response;
        }

        public async Task<bool> KVPutAsync(KVPair p, WriteOptions q)
        {
            var result = await _consulClient.KV.Put(p, q);
            return result.Response;
        }

        public async Task<bool> KVReleaseAsync(KVPair p)
        {
            var result = await _consulClient.KV.Release(p);
            return result.Response;
        }

        public async Task<bool> KVReleaseAsync(KVPair p, WriteOptions q)
        {
            var result = await _consulClient.KV.Release(p, q);
            return result.Response;
        }

        #endregion

        #region Common function 
        private byte[] GetByte(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        private string GetString(byte[] value)
        {
            if (value == null)
                return string.Empty;
            return Encoding.UTF8.GetString(value);
        }
        #endregion

        public void Dispose()
        {
            _consulClient?.Dispose();
        }
    }
}
