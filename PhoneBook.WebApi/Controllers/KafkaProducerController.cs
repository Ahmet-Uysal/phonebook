using System;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
namespace Kafka.Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KafkaProducerController : ControllerBase
    {
        private readonly ProducerConfig config = new ProducerConfig
        { BootstrapServers = "localhost:9092" };
        private readonly string topic = "simpletalk_topic";
        [HttpPost]
        [Route("[action]")]
        public IActionResult Post([FromBody] string message)
        {
            return Ok();
        }
        private Object SendToKafka(string topic, string message)
        {
            using (var producer =
                 new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Oops, something went wrong: {e}");
                }
            }
            return null;
        }
    }
}