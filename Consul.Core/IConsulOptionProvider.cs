﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consul.Core
{
    public interface IConsulOptionProvider
    {
        ConsulOption ConsulOption { get; }
    }
}
