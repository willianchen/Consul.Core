using Consul.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Core.Repositories
{
    public interface IConsulBaseRepository
    {
        Task<IEnumerable<T>> GetKVListAsync<T>(string key) where T : class;


        /// <summary>
        /// 添加/更新模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Info"></param>
        /// <returns></returns>
        Task<bool> PutKVAsync<T>(T Info) where T : BaseConsulModel;


        /// <summary>
        /// 删除KV
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Info"></param>
        /// <returns></returns>
        Task<bool> DeleteKVAsync<T>(T Info) where T : BaseConsulModel;

        Task<bool> DeleteKVAsync(string prefix);


        Task<T> GetKVAsync<T>(string key) where T : BaseConsulModel;

    }
}
