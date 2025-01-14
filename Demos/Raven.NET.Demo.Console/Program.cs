﻿using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raven.NET.Core.Observers;
using Raven.NET.Core.Configuration;
using Raven.NET.Core.Observers.Interfaces;
using Raven.NET.Core.Providers;
using Raven.NET.Core.Providers.Interfaces;

namespace Raven.NET.Demo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfiguration(builder);
            IConfiguration configuration = builder.Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.ConfigureRaven(configuration);
                }).Build();

            //var service = ActivatorUtilities.CreateInstance<RavenTypeWatcherDemoService>(host.Services);
            var service = ActivatorUtilities.CreateInstance<RavenWatcherDemoService>(host.Services);
            service.Run();
        }

        static void BuildConfiguration(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        } 
    }
}  