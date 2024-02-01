using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.ExcelCreate.Models;

namespace RabbitMQ.ExcelCreate.Data
{
	public class Context : IdentityDbContext
	{


		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected Context()
		{
		}

		public DbSet<UserFile> UserFiles { get; set; }
	}
}
