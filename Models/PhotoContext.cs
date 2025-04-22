using Microsoft.EntityFrameworkCore;

namespace Gallery_Api.Models
{
	public class PhotoContext : DbContext
	{
		public PhotoContext(DbContextOptions<PhotoContext> options) : base(
			options) { }
		public DbSet<PhotoApi> Photos { get; set; }
	}
}
