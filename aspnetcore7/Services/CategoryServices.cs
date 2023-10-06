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

		public async Task<List<Category>> GetList()
		{
			return await context.Category.ToListAsync();
		}
		
		public async Task<Category> Create(Category category)
		{
			context.Add(category);
			await context.SaveChangesAsync();
			return category;
		}

	}
}
