using PCRmq_Core.Entities.Icanhazdadjoke;
using PCRmq_Core.Entities.Solucx;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


namespace Consumer
{
    internal class Receiver
    {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "duda";
            factory.Password = "panama";
            factory.HostName = "192.168.99.66";
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    string message = GetPayloadMessage(ea.Body);
                    Console.WriteLine("Got:  {0} ", message);
                };

                channel.BasicConsume("BasicTest", true, consumer);

                Console.WriteLine("Press any key to close ");
                Console.WriteLine("[---]");
                Console.ReadLine();




            }


        }

        private static string GetPayloadMessage(ReadOnlyMemory<byte> body)
        {
            string message = Encoding.UTF8.GetString(body.ToArray());
            if (string.IsNullOrEmpty(message)) { return message; }
            DadJoke joke = JsonSerializer.Deserialize<DadJoke>(message);
            if (joke == null) { return string.Empty; }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(joke.id);
            builder.AppendLine(joke.joke);

            return builder.ToString();
        }
    }
}