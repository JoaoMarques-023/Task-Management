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
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public partial class L_TarefasEmCursoController : Controller
    {
        private SistemaDbContext Context { get; }

        public L_TarefasEmCursoController()
        {
            this.Context = new SistemaDbContext();
        }

        public IActionResult alinea7()
        {
            List<Tarefa> tarefas = this.Context.SearchTarefasalinea7().ToList();
            return View(tarefas);
        }
    }
}