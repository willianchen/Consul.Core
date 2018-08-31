using CML.Lib.Configurations;
using Consul.Core.Model;
using System;
using Xunit;

namespace Consul.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public async System.Threading.Tasks.Task ConsulClientTest()
        {
            var config = ConfigurationHelper.GetAppSettings<ConsulOption>("ConsulConfig");

            var option = new DefaultConsulOptionProvider().ConsulOption;
            ConsulNetClient client = new ConsulNetClient(option);

            string key = "app/keys";
            await client.KVPutAsync(key, "test");

            var value = await client.KVGetValueAsync(key);
            Console.Write(value);

            // Demo demo = new Demo() { ID = 1, Name = "°¢Àñ", Birth = DateTime.Now };

            BaseConsulModel demo = new BaseConsulModel() { Key = "Key", Path = "Common/EnvConfig/Key", Value = "Coding" };


            await client.KVPutAsync<BaseConsulModel>(demo.Path, demo);

            value = await client.KVGetValueAsync("app/demo");
            Console.WriteLine(value);
        }
    }
}
