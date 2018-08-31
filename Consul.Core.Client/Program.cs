using CML.Lib.Configurations;
using Consul.Core.Model;
using System;
using System.Threading.Tasks;

namespace Consul.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = ConfigurationHelper.GetAppSettings<ConsulOption>("ConsulConfig");
            var option = new DefaultConsulOptionProvider().ConsulOption;
            ConsulNetClient client = new ConsulNetClient(option);

            string key = "app/keys";
            client.KVPutAsync(key, "test");

            var value = client.KVGetValueAsync(key).Result;
            Console.Write(value);

            // Demo demo = new Demo() { ID = 1, Name = "阿礼", Birth = DateTime.Now };

            BaseConsulModel demo = new BaseConsulModel() { Key = "Key", Path = "Common/EnvConfig/Key", Value = "Coding" };


            client.KVPutAsync<BaseConsulModel>(demo.Path, demo);

            value = client.KVGetValueAsync("app/demo").Result;
            Console.WriteLine(value);
        }
    }
}
