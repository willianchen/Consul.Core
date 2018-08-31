using CML.Lib.Dependency;

namespace Consul.Core
{
    public static class ConsulDependencyExtension
    {
        /// <summary>
        /// 使用数据库
        /// </summary>
        /// <param name="containerManager"></param>
        /// <returns></returns>
        public static ContainerManager UseConsul(this ContainerManager containerManager)
        {
            containerManager.RegisterType<IConsulOptionProvider, DefaultConsulOptionProvider>(lifeStyle: LifeStyle.PerLifetimeScope);
            containerManager.RegisterType<IConsulClientProvider, ConsulNetClientProvider>(lifeStyle: LifeStyle.PerLifetimeScope);
            return containerManager;
        }
    }
}
