using System;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using WeChat.Shared;

namespace WeChat.HangfireTaskJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region log
            Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.Async(c => c.File("Logs/logs.txt"))
               .WriteTo.Async(c => c.Console())
               .CreateLogger();
            #endregion

            var host = CreateHostBuilder(args).Build();

            try
            {
                Log.Information("Start---console host.");
                host.Run();
                Log.Information("End-----console host.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAutofac()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();//Log ÒÀÀµ×¢Èë
    }
}
