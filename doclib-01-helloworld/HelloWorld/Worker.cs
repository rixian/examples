using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VendorHub.DocumentLibrary;

namespace HelloWorld
{
    public class Worker : BackgroundService
    {
        private readonly IDocumentLibraryClient client;
        private readonly ILogger<Worker> _logger;

        public Worker(IDocumentLibraryClient client, ILogger<Worker> logger)
        {
            this.client = client;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var libraryId = Guid.Parse("REPLACE_ME");
            ICollection<LibraryItemInfo> children =
                await this.client.ListChildrenAsync(libraryId, "/");

            _logger.LogInformation("Found children: {children}",
                JsonConvert.SerializeObject(children, Formatting.Indented));
        }
    }
}
