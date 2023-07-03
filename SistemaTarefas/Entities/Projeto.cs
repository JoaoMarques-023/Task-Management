

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace SistemaTarefas.Entities
{
    [Table("projects")]
    [Index(nameof(idproject), Name = "projects_idproject_uindex", IsUnique = true)]
    public partial class Projeto
    {
        [Key]
        [Column("idproject")]
        public int idproject { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(100)]
        
        [DisplayName("Nome")]
        public string nomeProjeto { get; set; }
        [Column("precohora")]
        [Range(0, int.MaxValue)]
        public decimal? precohora { get; set; }
        [Column("nomecliente")]
        public string nomecliente { get; set; }
        // public virtual User User { get; set; }
        // [InverseProperty(nameof(Tarefa.Projeto))]
        // public virtual ICollection<Projeto> Projetos { get; set; }
        public virtual IEnumerable<Tarefa> Tarefas { get; set; }
    }

}
