using PCRmq_Core.Entities.Solucx;
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

            Console.WriteLine("Press anu key to close ");
            Console.ReadLine();
        }

        private static string GetPayload()
        {
            Customer customer = new Customer
            {
                id = "41",
                client_id = "24944697830",
                name = "EDUARDO TEIXEIRA FURTADO",
                email = "eduardo.furtado@gmail.com",
                phone = "11976745086",
                phone2 = "",
                cpf = "24944697830",
                gender = null,
                opt_out = false,
                CreationDate = DateTime.Now
            };

            return JsonSerializer.Serialize(customer);

        }
    }
}