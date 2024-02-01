using Microsoft.EntityFrameworkCore;
using RabbitMQ.WebWatermark.Models;

namespace RabbitMQ.WebWatermark.Data
{
	public class Context : DbContext
    {

		protected Context()
		{
		}
		public Context(DbContextOptions options) : base(options)
		{
		}
	    public DbSet<RabbitMQ.WebWatermark.Models.Product> Product { get; set; } = default!;

		
	}
}
