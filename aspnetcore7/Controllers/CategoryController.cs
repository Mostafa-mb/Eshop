using aspnetcore7.Models;
using aspnetcore7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;

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
			if (category.Name.Length < 3)
			{
				ModelState.AddModelError("Name", "عنوان دسته بندی باید بیشتر از 3 کلمه باشد.");
			}

			if (ModelState.IsValid)
			{
				await Service.Create(category);
				RedirectToAction("Index");
			}

			return View(category);
		}

		public async Task<IActionResult> Details (int id)
		{
			var category = Service.GetAsync(id);
			return View(category);
		}
	}
}
