﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RedditImageBot.Services;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using RedditImageBot.Models;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RedditImageBot
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<HostedService>();
                services.ConfigureServices(hostContext.Configuration);
                services.AddAutoMapper(typeof(Program).Assembly);
                //services.RemoveAll<IHttpMessageHandlerBuilderFilter>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddNLog();
            });
    }
}
