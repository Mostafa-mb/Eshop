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
	}
}
