using aspnetcore7.Data;
using aspnetcore7.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore7.Services
{
	public class CategoryServices
	{
		private readonly AppDbContext context;

		public CategoryServices(AppDbContext context)
        {
			this.context = context;
		}

		public async Task<List<Category>> GetListAsync()
		{
			return await context.Category.ToListAsync();
		}
		
		public async Task<Category> GetAsync(int id)
		{
			return await context.Category.SingleOrDefaultAsync(e => e.Id == id);
		}
		
		public async Task<Category> Create(Category category)
		{
			context.Add(category);
			await context.SaveChangesAsync();
			return category;
		}

	}
}
