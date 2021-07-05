using Autofac;
using Autofac.Extras.DynamicProxy;
using EasyCaching.Interceptor.Castle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Demo.EasyCaching.Api
{
    public class AutofacSetup : Autofac.Module
    {
        /// <summary>
        /// 注册Autofac依赖注入服务
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Demo.EasyCaching.Service")).InstancePerLifetimeScope()
            .Where(type => !type.IsAbstract)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors();
            Assembly apiAssembly = Assembly.Load("Demo.EasyCaching.Api");
            builder.RegisterAssemblyTypes(apiAssembly);
            builder.ConfigureCastleInterceptor();//不能放到Startup中的ConfigureContainer方法里，要不然AOP缓存不生效
        }
    }
}
