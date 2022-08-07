using Confluent.Kafka;
using JyotiGyan.Common.DataBaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JyotiGyan.KafkaImplementation.ConsoleApp;
 
public sealed class ProducerHostedService : IHostedService
{
    private readonly ILogger _logger;
    private readonly DataContext _dataContext;
    public ProducerHostedService(ILogger<ProducerHostedService> logger, IHostApplicationLifetime appLifetime, IOptions<Object> option, IConfiguration configRoot,
        DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("1. StartAsync has been called.");



        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",//,localhost:9093,localhost:9094",
            ClientId = Dns.GetHostName()
        };

        Console.WriteLine($"{DateTime.Now} Press any key to continue to send account.. ");
        Console.ReadKey();
        var zipCodes = _dataContext.ZipCodes.Take(2).ToList();



        using (var producer = new ProducerBuilder<string, string>(config).Build())
        {
            Console.WriteLine($"{DateTime.Now} Sending the data.");

            foreach (var item in zipCodes)
            {
                string jsonString = JsonSerializer.Serialize(item);
                Console.WriteLine(jsonString);
                Console.WriteLine($"{DateTime.Now} ========================================================");
                await producer.ProduceAsync("zipcode", new Message<string, string> { Key = Guid.NewGuid().ToString(), Timestamp = Timestamp.Default, Value = jsonString });

            }
            Console.ReadLine();
        }
        //  return  await  Task.CompletedTask;

    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("4. StopAsync has been called.");

        //List<ZipCodeTemp> zipCodesTemp = new List<ZipCodeTemp>();
        //foreach (var zipCodeTemp in cc)
        //{
        //    var zc = new ZipCodeTemp
        //    {
        //        Id = zipCodeTemp.Id,
        //        Accuracy = zipCodeTemp.Accuracy,
        //        AreaCode = zipCodeTemp.AreaCode,
        //        City = zipCodeTemp.City,
        //        Code = zipCodeTemp.Code,
        //        Lat = zipCodeTemp.Lat,
        //        Lon = zipCodeTemp.Lon,
        //        StateId = zipCodeTemp.StateId,
        //    };
        //    zipCodesTemp.Add(zc);
        //}
        //_dataContext.ZipCodesTemps.AddRangeAsync(zipCodesTemp);
        //_dataContext.SaveChanges();
        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        _logger.LogInformation("2. OnStarted has been called.");
    }

    private void OnStopping()
    {
        _logger.LogInformation("3. OnStopping has been called.");
    }

    private void OnStopped()
    {
        _logger.LogInformation("5. OnStopped has been called.");
    }
}