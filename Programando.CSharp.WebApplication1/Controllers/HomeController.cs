using Microsoft.AspNetCore.Mvc;
using Programando.CSharp.WebApplication1.Model;
using Programando.CSharp.WebApplication1.Models;
using System.Diagnostics;

namespace Programando.CSharp.WebApplication1.Controllers
{
	public class HomeController : Controller
	{

        public IActionResult Index()
		{
			return View();
		}
	}
}