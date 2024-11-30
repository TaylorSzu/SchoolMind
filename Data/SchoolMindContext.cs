using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Mind.Models;

namespace School_Mind.Data
{
    public class SchoolMindContext : DbContext
    {
        public SchoolMindContext(DbContextOptions<SchoolMindContext> options) : base(options){}

        public DbSet<Account> Account { get; set; }
        public DbSet<StudentProfile> Student { get; set; }
        public DbSet<Class> Class {get; set;}
        public DbSet<Calendar> Calendar {get; set;}
        public DbSet<TeachingMaterial> TeachingMaterial {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //codigo para fazer a chave estrangeira
            modelBuilder.Entity<Class>().HasOne(c=>c.Creator).WithMany(c=>c.Class).HasForeignKey(c=>c.AccountId);

            //Chave estrageira para estudante
            modelBuilder.Entity<StudentProfile>().HasOne(sp=>sp.Account).WithMany(sp=>sp.Students).HasForeignKey(sp=>sp.AccountId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudentProfile>().HasOne(sp => sp.Class).WithMany(c => c.Students).HasForeignKey(sp=>sp.ClassId).OnDelete(DeleteBehavior.Cascade);

            //Chave estrageira para calendario
            modelBuilder.Entity<Calendar>().HasOne(c=>c.Creator).WithMany(c=>c.Calendars).HasForeignKey(c=>c.AccountId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Calendar>().HasOne(c=>c.Class).WithMany(c=>c.Calendars).HasForeignKey(c=>c.ClassId).OnDelete(DeleteBehavior.Restrict);

            //Chave estrageira para material didatico
            modelBuilder.Entity<TeachingMaterial>().HasOne(t=>t.Creator).WithMany(t=>t.TeachingMaterials).HasForeignKey(t=>t.AccountId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TeachingMaterial>().HasOne(t=>t.Class).WithMany(t=>t.TeachingMaterials).HasForeignKey(t=>t.ClassId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}