using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Pdf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.Migicodes.IE.Test
{
    public class IocContainer
    {
        public static IContainer container;
        public static IHost host;
        public static IocContainer Instance => new IocContainer();

        public void Regist()
        {
            host = new HostBuilder().ConfigureServices((hostContext, _services) =>
            {
                _services.AddLogging();
            })
                    .Build();

            host.RunAsync();

            IServiceCollection services = new ServiceCollection();

            services.AddLogging();

            CreateAutofacServiceProvider(services);
        }

        private void CreateAutofacServiceProvider(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<ExcelImporter>().As<IExcelImporter>().InstancePerLifetimeScope();
            builder.RegisterType<ExcelExporter>().As<IExcelExporter>().InstancePerLifetimeScope();
            builder.RegisterType<PdfExporter>().As<IPdfExporter>().InstancePerLifetimeScope();
            container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            new AutofacServiceProvider(container);
        }
    }
}
