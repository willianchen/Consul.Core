using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Core
{
    public class ConsulNetClientProvider : IConsulClientProvider
    {
        public IConsulClient CreateConsulClient(ConsulOption option)
        {
            return new ConsulNetClient(option);
        }
    }
}
