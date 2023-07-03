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
    public partial class L_TarefasFinalizadasController : Controller
    {
        private SistemaDbContext Context { get; }

        public L_TarefasFinalizadasController()
        {
            this.Context = new SistemaDbContext();
        }

        public IActionResult alinea8()
        {
            List<Tarefa> tarefas = this.Context.SearchTarefas(DateTime.MinValue, DateTime.MaxValue).ToList();
            return View(tarefas);
        }

        [HttpPost]
        public IActionResult alinea8(string datainicial,string datafinal)
        {
            DateTime datainicial2;
            DateTime datafinal2;
            if (datainicial == null)
            { 
                datainicial2 = DateTime.MinValue;
            }
            else
            {
                datainicial2 = DateTime.ParseExact(datainicial,"yyyy-MM-dd",CultureInfo.InvariantCulture);
            }

            if (datafinal == null)
            {
                datafinal2=DateTime.MaxValue;
            }
            else
            {
                datafinal2 = DateTime.ParseExact(datafinal,"yyyy-MM-dd",CultureInfo.InvariantCulture);
            }
            List<Tarefa> tarefas = this.Context.SearchTarefas(datainicial2,datafinal2).ToList();
            return View(tarefas);
        }
    }
}