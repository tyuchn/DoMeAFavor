
using System.Net;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace DoMeAFavor.DataService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options => options.Listen(IPAddress.Any,13059))
                .Build();
    }
}
