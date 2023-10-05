using Microsoft.AspNetCore.Mvc;

namespace aspnetcore7.Controllers
{
	public class CategoryController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
