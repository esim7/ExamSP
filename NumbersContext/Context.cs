using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace NumbersContext
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }
        public DbSet<Report> Reports { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A-104-13;Database=ExamDB;Trusted_Connection=True;");
        }
    }
}
