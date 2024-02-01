using Microsoft.EntityFrameworkCore;

namespace RabbitMQ.WebWatermark.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected AppDbContext()
		{
		}

		public DbSet<Product> Products { get; set; }
	}
}
