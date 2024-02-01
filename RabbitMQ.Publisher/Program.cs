public class program
{

	static void Main()
	{
		// Giriş noktası kodları burada olmalıdır.
	}
	//private static async void main(string[] args)
	//{
	//	//bağlantı oluşturma 1. aşama
	//	var factory = new ConnectionFactory();

	//	factory.uri = new uri("amqps://iclowame:ecgymv4l6fcqlh3ozawsbvwmtz4gppzd@toad.rmq.cloudamqp.com/iclowame");

	//	//bağlantıyı aktifleşme ve kanal açma
	//	using iconnection connection = factory.createconnection();

	//	using imodel channel = connection.createmodel();


	//	//queue oluşturma
	//	channel.queuedeclare(queue: "hello-queue", exclusive: false, durable: false); //durable özelliği mesajarı kalıcı 

	//	//queue' ya mesaj gönderme 
	//	//rabitmq kuyruğa atacağı mesajları byte türünden kabul etmektedir.bu yüxden mesajları byte dönüştürmemeiz gerekmektdir.

	//	asicproperties properties = channel.createbasicproperties();
	//	properties.persistent = true;

	//	for (int i = 0; i < 100; i++)
	//	{
	//		await task.delay(200);
	//		byte[] message = encoding.utf8.getbytes("merhaba" + i);
	//		channel.basicpublish(exchange: "", routingkey: "hello-queue", body: message, basicproperties: properties);
	//	}

	//	console.read();


	//	//string message ="hello word";

	//	//   var messagebody = encoding.utf8.getbytes(message); //göndermek için byte çevirdik.
	//	//channel.basicpublish(string.empty, "hello-queue",null,messagebody, basicproperties:properties);
	//	//console.writeline("mesajınız gönderilmiştir.");
	//	//console.readline();










	//}
}