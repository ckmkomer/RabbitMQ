using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://iclowame:LW_624OMO9yvqmcG6-bnG25vSHI3m0a0@toad.rmq.cloudamqp.com/iclowame");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
	exchange: "topic-exchange-example",
	type: ExchangeType.Topic
	);

for (int i = 0; i < 100; i++)
{
	await Task.Delay(200);
	byte[] message = Encoding.UTF8.GetBytes($"Merhaba {i}");
	Console.Write("Mesajın gönderileceği topic formatını belirtiniz : ");
	string topic = Console.ReadLine();
	channel.BasicPublish(
		exchange: "topic-exchange-example",
		routingKey: topic,
		body: message
		);
}

Console.Read();