using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVP.Entidades;
using MVP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MVPDbContext _context;
        public HomeController(MVPDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var x = _context.SituacaoUsuario.ToList();
            SituacaoUsuario situacaoUsuario = new SituacaoUsuario();
            return View(situacaoUsuario);
        }

        [HttpPost]
        public IActionResult Index(SituacaoUsuario situacaoUsuario)
        {
            SituacaoUsuario situacao = _context.SituacaoUsuario.SingleOrDefault(x => x.CPF == situacaoUsuario.CPF);
            if(situacao == null)
            {
                return View("NotFound");
            }
            return View("Resultado", situacao);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
