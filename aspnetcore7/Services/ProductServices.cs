using aspnetcore7.Data;
using aspnetcore7.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore7.Services
{

	public class ProductServices
	{
			private readonly AppDbContext context;

			public ProductServices(AppDbContext context)
			{
				this.context = context;
			}

			public async Task<List<Product>> GetListAsync()
			{
				return await context.Product.ToListAsync();
			}

			public async Task<Product> Create(Product Product)
			{
				context.Add(Product);
				await context.SaveChangesAsync();
				return Product;
			}

	}

}
