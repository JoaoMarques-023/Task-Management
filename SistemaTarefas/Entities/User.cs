
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SistemaTarefas.Entities
{
    [Table("users")]
    public partial class User
    {
        [Key]
        [Column("idUser")]
        public int idUser { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string password { get; set; }
        [Column("name")]
        [StringLength(100)]
        public string name { get; set; }
        [Column("nhoras")]
        public int? nhoras { get; set; }
    }
}

