using aspnetcore7.Models;
using aspnetcore7.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore7.Controllers
{
	public class ProductController : Controller
	{
		public ProductController(ProductServices service)
		{
			Service = service;
		}
		public ProductServices Service { get; }


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
		public async Task<IActionResult> Create(Product Product)
		{
			if (Product.Name.Length < 3)
			{
				ModelState.AddModelError("Name", "عنوان دسته بندی باید بیشتر از 3 کلمه باشد.");
			}

			if (ModelState.IsValid)
			{
				await Service.Create(Product);
				RedirectToAction("Index");
			}

			return View(Product);
		}
	}
}
