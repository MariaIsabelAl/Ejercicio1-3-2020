using Microsoft.EntityFrameworkCore;
using Ejercicio1_3_2020.Models;
using System;

namespace Ejercicio1_3_2020.DAL
{
    public class Contexto : DbContext
    {
        
        public DbSet<Estudiantes> Estudiantes { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Registro.db");
        }

       
    }
}
       