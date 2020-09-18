using Microsoft.EntityFrameworkCore;
using Ejercicio1_3_2020.Models;
using System;

namespace Ejercicio1_3_2020.DAL
{
    public class Contexto : DbContext
    {
        
        public Contexto(DbContextOptions options) :base(options){}
        public DbSet<Estudiantes> Estudiantes { get; set; }

       
    }
}
       