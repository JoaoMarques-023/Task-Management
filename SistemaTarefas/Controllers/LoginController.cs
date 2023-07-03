using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemaTarefas.Context;
using SistemaTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaTarefas.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaDbContext _context;

        public LoginController()
        {
            _context = new SistemaDbContext();
        }
        
        public IActionResult Login()
        {
            return View();
        }  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
        {
            // var passHash = $"\\x{ComputeSha256Hash(login.Password)}";

            var user = _context.Users
                .FirstOrDefault(u => u.email.Equals(login.Email) && u.password.Equals(login.Password));

            if (user != null)
            {
                UserSession.UserId = user.idUser;
                UserSession.Username = user.name;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }
            
            ViewData["HasError"] = true;
            
            return View(login);
        }
        
        
        public IActionResult Logout()
        {
            UserSession.UserId = null;
                UserSession.Username = null;
                return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
        
        public IActionResult AlterarDados()
        {
            return (null);
        }
        
        /*static string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }*/
    }
}