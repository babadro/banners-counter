using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BannersCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var file = File.CreateText("banners.json"))
            {
                var bannersInfo = new List<Banner>()
                {
                    new Banner(1, 0),
                    new Banner(2, 0),
                    new Banner(3, 0),
                    new Banner(4, 0),
                    new Banner(5, 0)
                };
                var serializer = new JsonSerializer();

                serializer.Serialize(file, bannersInfo);
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
