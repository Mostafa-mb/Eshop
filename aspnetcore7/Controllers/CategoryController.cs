using aspnetcore7.Models;
using aspnetcore7.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore7.Controllers
{
	public class CategoryController : Controller
	{
        public CategoryController(CategoryServices service)
        {
			Service = service;
		}
		public CategoryServices Service { get; }


		public async Task<IActionResult> Index()
		{
			var list = await Service.GetListAsync();
			return View(list);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			await Service.Create(category);
			return View(category);
		}
	}
}
