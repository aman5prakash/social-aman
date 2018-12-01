using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SocialServer.Consumers
{
    public class TopicConsumer
    {
        public TopicConsumer()
        {
            Console.WriteLine("Listening from RabbitMQ");
            GetTopicsFromRabbitMQ();
        }
        public void GetTopicsFromRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "rabbitmq", Password = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Topic", durable: false, exclusive: false, autoDelete: false, arguments: null);
                
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "Topic", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    
    }
}