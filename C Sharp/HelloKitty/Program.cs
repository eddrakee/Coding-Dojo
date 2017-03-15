using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Dojodachi
{
    public class HelloKitty
    {
        public int Happiness = 20;
        public int Fullness = 20;
        public int Energy = 50;
        public int Meals = 5;
        public string Message = "";

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}