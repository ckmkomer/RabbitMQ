﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://iclowame:LW_624OMO9yvqmcG6-bnG25vSHI3m0a0@toad.rmq.cloudamqp.com/iclowame");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
	exchange: "fanout-exchange-example",
	type: ExchangeType.Fanout);

Console.Write("Kuyruk adını giriniz : ");
string queueName = Console.ReadLine();

channel.QueueDeclare(
	queue: queueName,
	exclusive: false);

channel.QueueBind(
	queue: queueName,
	exchange: "fanout-exchange-example",
	routingKey: string.Empty
	);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
	queue: queueName,
	autoAck: true,
	consumer: consumer);
consumer.Received += (sender, e) =>
{
	string message = Encoding.UTF8.GetString(e.Body.Span);
	Console.WriteLine(message);
};

Console.Read();