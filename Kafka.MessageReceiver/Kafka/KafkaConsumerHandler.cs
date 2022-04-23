using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Report.Worker.Concrete;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Report.Kafka
{
    public class KafkaConsumerHandler : IHostedService
    {

        private readonly string topic = "simpletalk_topic";
        public Task StartAsync(CancellationToken cancellationToken)
        {

            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using (var builder = new ConsumerBuilder<Ignore,
                string>(conf).Build())
            {
                builder.Subscribe(topic);
                var cancelToken = new CancellationTokenSource();
                try
                {
                    while (true)
                    {
                        var consumer = builder.Consume(cancelToken.Token);
                        switch (consumer.Message.Value)
                        {
                            case "CreateReport":
                                System.Console.WriteLine("==>" + consumer.Message.Value);
                                new ReportCreater().CreateReport();
                                break;
                            default: break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    builder.Close();
                }
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}