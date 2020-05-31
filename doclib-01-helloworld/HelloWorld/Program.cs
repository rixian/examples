using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rixian.Extensions.Tokens;
using VendorHub.DocumentLibrary.DependencyInjection;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDocumentLibraryClient(new DocumentLibraryClientOptions
                    {
                        DocumentLibraryApiUri = new Uri("https://api.vendorhub.io"),
                        TokenClientOptions = new ClientCredentialsTokenClientOptions
                        {
                            Authority = "https://identity.vendorhub.io",
                            ClientId = "REPLACE_ME",
                            ClientSecret = "REPLACE_ME"
                        }
                    });
                });
    }
}
