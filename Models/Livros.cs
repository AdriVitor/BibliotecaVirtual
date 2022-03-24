using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livros.Models 
{
    [Table("Livros")]
    public class livro 
    {
        
      [Key]public int Id { get; set; }

        public string Titulo { get; set; }

        public string Genero { get; set; }

        public DateTime Dt_Lancamento { get; set; }
    }
}