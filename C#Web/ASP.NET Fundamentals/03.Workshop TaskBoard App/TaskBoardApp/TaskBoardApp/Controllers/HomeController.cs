using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
	public class HomeController : Controller
	{
		public HomeController() 
		{ 

		}

		public IActionResult Index()
		{
			return View();
		}

	}
}