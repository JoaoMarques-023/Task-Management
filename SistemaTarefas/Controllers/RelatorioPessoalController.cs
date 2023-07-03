using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public partial class RelatorioPessoalController : Controller
    {
        private SistemaDbContext Context { get; }

        public RelatorioPessoalController()
        {
            this.Context = new SistemaDbContext();
        }

        public IActionResult alinea11()
        {
            List<Tarefa> tarefas = this.Context.SearchTarefas(DateTime.MinValue, DateTime.MaxValue).ToList();
            return View(tarefas);
        }

        [HttpPost]
        public IActionResult alinea11(int id,string data)
        {
            DateTime data2;
            data2 = DateTime.ParseExact(data,"yyyy-MM-dd",CultureInfo.InvariantCulture);
            
            List<Tarefa> tarefas = this.Context.SearchTarefasalinea11(data2,id).ToList();
            return View(tarefas);
        }
    }
}