using Microsoft.AspNetCore.Mvc;
using Programando.CSharp.WebApplication1.Model;

namespace Programando.CSharp.WebApplication1.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ModelNorthwind _context;

        public EmpleadosController(ModelNorthwind context)
        { 
            _context = context;
        }

        public IActionResult Index()
        {
            var empleados = _context.Employees.ToList();

            return View(empleados);
        }
    }
}
