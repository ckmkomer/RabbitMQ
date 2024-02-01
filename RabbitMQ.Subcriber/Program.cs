using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


//Bağlantı oluşturma 
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://iclowame:ECgyMv4l6FcQLH3OzawSBvWMtZ4GppZD@toad.rmq.cloudamqp.com/iclowame");
using (var connection = factory.CreateConnection())
{
	//Bağlantı aktifleşme ve kanal açma
	var channel = connection.CreateModel();
	channel.QueueDeclare("hello-queue", true, false, false);//Consumerda da kuyruk publisherdaki ile birebir aynı yapılandırmada tanımlanmalıdır.

	//Queue Oluşturma //Queu dan mesaj okuma

	var consumer = new EventingBasicConsumer(channel);
	channel.BasicConsume(queue:"hello-queue",autoAck:false, consumer);// autoAck metodu ile mesajlar direkt olarak kuyruktan silinmiyecek.

	
	consumer.Received += (object sender, BasicDeliverEventArgs e) =>
	{
		//Kuyruğa gelen mesajın işlendiğiyerdir.
		//e.Body:Kuruktaki mesajın verisini bütünsel olarak geitirecektir.
		//e.body.span veya e.Body.ToArry():Kuyruktaki byte verisini getirecektir.

		var message = Encoding.UTF8.GetString(e.Body.ToArray());

		Console.WriteLine( message);
		channel.BasicAck(deliveryTag:e.DeliveryTag,multiple:false);
		//deliverTag:Bildirimde bulunacağımız mesaja dair unige bir değerdir.

	};

	Console.ReadLine();

	

}
