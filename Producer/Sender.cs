using PCRmq_Core.Entities.Icanhazdadjoke;
using PCRmq_Core.Entities.Solucx;
using PCRmq_Core.Service.Icanhazdadjoke;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Producer
{
    internal class Sender
    {
        private static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "duda";
            factory.Password = "panama";
            factory.HostName = "192.168.99.66";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = GetPayload();
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent {0} ", message);
            }

            Console.WriteLine("Press any key to close ");
            Console.ReadLine();
        }

        private static string GetPayload()
        {

            DadJoke joke = JokeService.GetRandomJokeAsync().Result;

            return JsonSerializer.Serialize(joke);

        }
    }
}