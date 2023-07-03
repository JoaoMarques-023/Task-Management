using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SistemaTarefas.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Http;

namespace SistemaTarefas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SistemaDbContext _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = new SistemaDbContext();
        }

        public IActionResult Index()
        {
            /*var user = _db.Users.Find(UserSession.UserId);
            ViewData["User"] = user;*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Clients()
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