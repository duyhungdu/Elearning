using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Pipeline;
using StructureMap.Web.Pipeline;
using LiteSchool.Library.Logging;
using LiteSchool.Library.Structuremap;
using LiteSchool.Entities;
using LiteSchool.Dtos;
using LiteSchool.Library.Cache;
using System.Runtime.Caching;
using LiteSchool.Presentation;
using LiteSchool.Core.IPresentation;
using LiteSchool.Core.IServices;
using LiteSchool.Core.Factories;
using LiteSchool.Library.Helpers;
using AutoMapper;

namespace LiteSchool.Assembler
{
    /// <summary>
    /// Bootstrapper class is used to initialize the application on start
    /// </summary>
    public static class Bootstrapper
    {
        
        public static IContainer Init(ServiceAccessMode mode, ILifecycle serviceLifecycle)
        {
            var container = new Container();
            try
            {
                container = new Container(x =>
                    {
                        x.For<ILogger>().Singleton().Use<Log4NetAdapter>();

                        MemoryCache cache = new MemoryCache("app_cache");
                        x.For<ICacheStorage>().Singleton().Use<MemoryCacheStorage>().Ctor<MemoryCache>("cache").Is(cache);

                        x.AddRegistry(new RepositoryRegistry(serviceLifecycle));
                        if (mode == ServiceAccessMode.InProcess)
                            x.AddRegistry(new ServiceRegistry(serviceLifecycle));
                        x.AddRegistry<PresentationRegistry>();
                        x.AddRegistry<FactoryRegistry>();
                    });
                AutoMapperConfig.CreateMappings();

                  // InitStaticCache();

                Resolve<ILogger>(container).Log("App started");
            }
            catch (Exception ex)
            {
                try
                {
                    Resolve<ILogger>(container).Log("App failed on start", ex);
                }
                catch (Exception)
                {

                }
                throw;
            }
            return container;
        }

        private static void InitStaticCache()
        {
            var types = ReflectionHelper.InterfaceScan<IStaticCache>("LiteSchool.Core");
            foreach (var type in types)
                ((IStaticCache)new Container().TryGetInstance(type)).InitStaticCache();
        }

        public static T Resolve<T>(Container container) where T : class
        {
            return (T)container.TryGetInstance(typeof(T));
        }
    }

    public enum ServiceAccessMode
    {
        InProcess,
        Proxy
    }
}