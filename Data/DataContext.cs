using System;
using Microsoft.EntityFrameworkCore;
using Livros.Models;

namespace Livraria.Data 
{
    public class DataContext : DbContext 
    {
        public DbSet<livro> livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer(@"Server=DESKTOP-H7797U1\SQLEXPRESS;
                                Database=Biblioteca;
                                Integrated Security=True");
        }
    }
}