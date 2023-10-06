using Microsoft.EntityFrameworkCore;

namespace aspnetcore7.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }
    }
}
