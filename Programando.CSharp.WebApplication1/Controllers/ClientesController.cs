using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication1.Model;

namespace Programando.CSharp.WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ModelNorthwind _context;
        private readonly HttpClient _http;

        public ClientesController(ModelNorthwind context, HttpClient http)
        {
            _context = context;
            _http = http;
        }

        public IActionResult Index()
        {
            var clientes = _context.Customers
                .OrderBy(r => r.CompanyName)
                .ToList();

            return View(clientes);
        }

        public IActionResult Index2()
        {
            var clientes = _http.GetFromJsonAsync<List<Customer>>("http://localhost:5195/api/customers").Result;

            return View(clientes);
        }
    }
}
