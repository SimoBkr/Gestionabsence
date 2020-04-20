using System;
using System.Collections.Generic;
using System.Text;
using coreProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace coreProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> User {get; set;}
        public DbSet<Filiere> Filiere {get; set;}
        public DbSet<Etudiant> Etudiant {get; set;}
        public DbSet<Professeur> Professeur {get; set;}
        public DbSet<Matiere> Matiere {get; set;}

        public DbSet<Absence> Absence {get; set;}

        public DbSet<Seance> Seance {get; set;}
        public DbSet<Administration> Administration {get; set;}


    }
}
