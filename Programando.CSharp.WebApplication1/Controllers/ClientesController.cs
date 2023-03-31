using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication1.Model;

namespace Programando.CSharp.WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ModelNorthwind _context;

        public ClientesController(ModelNorthwind context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Customers.ToList();

            return View(clientes);
        }
    }
}
