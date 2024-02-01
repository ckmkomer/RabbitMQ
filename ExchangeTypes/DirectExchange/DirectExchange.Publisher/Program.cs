using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://iclowame:ECgyMv4l6FcQLH3OzawSBvWMtZ4GppZD@toad.rmq.cloudamqp.com/iclowame");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);//davranış olarak direktexchange 

while (true)
{
	Console.Write("Mesaj : ");
	string message = Console.ReadLine();
	byte[] byteMessage = Encoding.UTF8.GetBytes(message);

	channel.BasicPublish(
		exchange: "direct-exchange-example",
		routingKey: "direct-queue-example", //hangi kuruğa gideceğini 
		body: byteMessage);//hangi mesajı göndereceğimiz.
}

Console.Read();