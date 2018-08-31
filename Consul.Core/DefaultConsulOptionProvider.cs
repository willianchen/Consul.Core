
using CML.Lib.Configurations;

namespace Consul.Core
{
    public class DefaultConsulOptionProvider : IConsulOptionProvider
    {
        const string ConsulConfig = "ConsulConfig";
        public ConsulOption ConsulOption
        {
            get
            {
                return ConfigurationHelper.GetAppSettings<ConsulOption>(ConsulConfig);
            }
        }
    }
}
