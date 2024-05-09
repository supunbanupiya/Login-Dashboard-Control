using Microsoft.EntityFrameworkCore;

namespace LogiinLogout.Models
{
	public class mycontext : DbContext
	{
		public mycontext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<employee> employees { get; set; }
	}
}
