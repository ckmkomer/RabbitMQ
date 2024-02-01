using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://iclowame:LW_624OMO9yvqmcG6-bnG25vSHI3m0a0@toad.rmq.cloudamqp.com/iclowame");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
	exchange: "header-exchange-example",
	type: ExchangeType.Headers);

for (int i = 0; i < 100; i++)
{
	await Task.Delay(200);
	byte[] message = Encoding.UTF8.GetBytes($"Merhaba {i}");
	Console.Write("Lütfen header value'sunu giriniz : ");
	string value = Console.ReadLine();

	IBasicProperties basicProperties = channel.CreateBasicProperties();//oluşturduğumuz nesne
	basicProperties.Headers = new Dictionary<string, object>
	{
		["no"] = value
	};

	channel.BasicPublish(
		exchange: "header-exchange-example",
		routingKey: string.Empty,
		body: message,
		basicProperties: basicProperties /// headdere değeri basicProperties üzweinden bir nesne oluşturmamaız gerekior:
		);
}

Console.Read();