using System;
using SistemaTarefas.Entities;

namespace SistemaTarefas.Models
{
    public class ProjetoViewModel
    { 
        public ProjetoViewModel(Entities.Projeto proj)
        {
            this.nome = proj.nomeProjeto;
            this.precohora = proj.precohora ?? 0;
            this.nomecliente = proj.nomecliente;
        }
        
        public string nome { get; set; }
        public decimal precohora { get; set; }
        
        public string nomecliente { get; set; }
    }
}