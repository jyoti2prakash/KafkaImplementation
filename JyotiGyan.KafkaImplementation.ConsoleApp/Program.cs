using JyotiGyan.Common;
using JyotiGyan.Common.DataBaseContext;
using JyotiGyan.KafkaImplementation.ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //   var cc= hostContext.Configuration.GetConnectionString("SqlLite");
        //    services.AddDbContext<SqlLiteDataContext>(
        //// options => options.UseSqlite("name=ConnectionStrings:DefaultConnection")
        //// );

        services.ConfigureServices();
      //  services.AddHostedService<ProducerHostedService>();
        services.AddHostedService<ConsumerHostedService>();

    }).Build();

// Application code should start here.

await host.RunAsync();