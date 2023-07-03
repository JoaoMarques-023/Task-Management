/*using System;
using System.Linq;
using SistemaTarefas.Context;
using SistemaTarefas.Entities;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public class OldMealsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var userId = (int?)null;
            try
            {
                userId = int.Parse(HttpContext.Request.Query["idUser"]);
            } catch {}

            var db = new MealsDbContext();
            
            var meals = db.Projects
                // .Include(m => m.User)
                .AsQueryable();

            if (userId != null)
            {
                meals = meals.Where(m => m.idproject == userId);
            }
            
            return View(meals
                .Select(m => new MealViewModel(m))
                .ToList());
        }
        
    }
}*/