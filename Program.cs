using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TotalFitnes
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
              
            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel(options => {
                    options.NoDelay = true;
                    options.ThreadCount = 4;
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
