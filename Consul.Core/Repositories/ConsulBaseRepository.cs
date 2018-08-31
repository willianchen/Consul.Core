using Consul.Core.Model;
using Consul.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Core
{
    public class ConsulBaseRepository : IConsulBaseRepository
    {
        private readonly IConsulClientProvider _consulClientProvider;
        private IConsulClient _client;

        public ConsulBaseRepository(IConsulClientProvider consulClientProvider, IConsulOptionProvider consulOptionProvider)
        {
            _consulClientProvider = consulClientProvider;
            ConsulOptionProvider = consulOptionProvider;
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        protected IConsulOptionProvider ConsulOptionProvider { get; }

        /// <summary>
        /// 实例
        /// </summary>
        public IConsulClient Client
        {
            get
            {
                return _client ?? (_client = _consulClientProvider.CreateConsulClient(ConsulOptionProvider.ConsulOption));
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetKVListAsync<T>(string key) where T : class
        {
            var result = Client.KVListAsync<T>(key);
            return result;
        }

        /// <summary>
        /// 添加/更新模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Info"></param>
        /// <returns></returns>
        public Task<bool> PutKVAsync<T>(T Info) where T : BaseConsulModel
        {
            var result = Client.KVPutAsync<T>(Info.Path, Info);
            return result;
        }

        /// <summary>
        /// 删除KV
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Info"></param>
        /// <returns></returns>
        public Task<bool> DeleteKVAsync<T>(T Info) where T : BaseConsulModel
        {
            var result = Client.KVDeleteAsync(Info.Path);
            return result;
        }

        public Task<T> GetKVAsync<T>(string key) where T : BaseConsulModel
        {
            if (string.IsNullOrWhiteSpace(key)) return Task.FromResult(default(T));
            var result = Client.KVGetAsync<T>(key);
            return result;
        }

        public Task<bool> DeleteKVAsync(string prefix)
        {
            return Client.KVDeleteAsync(prefix);
        }
    }
}
