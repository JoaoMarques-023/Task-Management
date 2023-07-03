using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace SistemaTarefas.Entities

{     
    [Table("tarefas")]  

    public partial class Tarefa
    {
        [Key]
        [Column("id_tarefa")]
        public int id_tarefa { get; set; }
        
        [Column("hora_inicio", TypeName = "DateTime")]
        public DateTime hora_inicio { get; set; }
        
        [Column("hora_fim", TypeName = "DateTime")]
        public DateTime? hora_fim { get; set; }
        
        [Column("estado")]
        public string estado { get; set; }
        
        [Column("descricao")]
        public string descricao { get; set; }
        
        [Column("precohora")]
        public decimal? precohora { get; set; }
        
        [ForeignKey("Projetos")]
        public int? id_projeto { get; set; }
        public virtual Projeto Projetos { get; set; }
        
        [ForeignKey("Users")]
        public int? id_utilizador { get; set; }
        public virtual User Users { get; set; }
        
        // [Column("id_utilizador")]
        // public int id_utilizador { get; set; }
        // [ForeignKey(nameof(id_utilizador))]
        // [InverseProperty("Projects")]
        // public virtual User User { get; set; }
    }
}