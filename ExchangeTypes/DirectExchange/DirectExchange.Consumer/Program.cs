using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://iclowame:ECgyMv4l6FcQLH3OzawSBvWMtZ4GppZD@toad.rmq.cloudamqp.com/iclowame");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//1. Adım : Publisher'da ki exchange ile birebir aynı isim ve type'a sahip bir exchange tanımlanmalıdır!
channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);

//2. Adım : Publisher tarafından routing key'de bulunan değerdeki kuyruğa gönderilen mesajları, kendi oluşturduğumuz kuyruğa yönlendirerek tüketmemiz gerekmektedir. Bunun için öncelikle bir kuyruk oluşturulmalıdır!
string queueName = channel.QueueDeclare().QueueName;

//3. Adım : routin keye karşılık gönderilmiş mesajları bu kuyruğa göndermiş oluyouz.
channel.QueueBind(
	queue: queueName,
	exchange: "direct-exchange-example",
	routingKey: "direct-queue-example");

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



