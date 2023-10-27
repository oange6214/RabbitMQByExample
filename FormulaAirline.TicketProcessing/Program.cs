using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Welcome to the ticketing service");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/"
};

var conn = factory.CreateConnection();
using var channel = conn.CreateModel();

channel.QueueDeclare("bookings", durable: false, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, EventArgs) =>
{
    // getting my byte[]
    var body = EventArgs.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"New ticket processing in initiated for - {message}");
};

channel.BasicConsume("bookings", true, consumer);

Console.ReadKey();