using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;

namespace SistemaTarefas.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly SistemaDbContext _context;

        public ProjetosController()
        {
            _context = new SistemaDbContext();
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {
            var SistemaDbContext = _context.Projects;
            return View(await SistemaDbContext.OrderBy(m => m.nomecliente).ToListAsync());
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.Include(x => x.Tarefas).Where(y=>y.idproject == id).FirstOrDefaultAsync(m => m.idproject == id);
            //var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            // ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nomeProjeto,precohora,nomecliente")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", projeto.idproject);
            return View(projeto);
        }

        // GET: Meal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproject,nomeProjeto,precohora,nomecliente")] Projeto projeto)
        {
            if (id != projeto.idproject)
            {
                return NotFound();
            }

            var errors = new List<string>();

            if (projeto.precohora is < 0)
            {
                errors.Add("The price can't be negative");
            }

            if (ModelState.IsValid && errors.Count <= 0)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(projeto.idproject))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Errors"] = errors;
            return View(projeto);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Projects.FindAsync(id);
            var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
            if (meal != null)
            {
                foreach (var tarefa in tarefas)
                {
                    tarefa.Projetos = null;
                    tarefa.id_projeto = null;
                    _context.Tarefas.Update(tarefa);
                }
                _context.Projects.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteALL(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Projects.FirstOrDefaultAsync(m => m.idproject == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }
        // POST: Meal/Delete/5
        [HttpPost, ActionName("DeleteALL")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProjTarefas(int id)
        {
            var meal = await _context.Projects.FindAsync(id);
            var tarefas = await _context.Tarefas.Where(m => m.id_projeto == meal.idproject).ToListAsync();
            if (meal != null)
            {
                foreach (var tarefa in tarefas)
                {
                    _context.Tarefas.Remove(tarefa);
                }
                _context.Projects.Remove(meal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Projects.Any(e => e.idproject == id);
        }
    }
}
