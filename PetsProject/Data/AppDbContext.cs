using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<VetRegistracion> GetVetRegistraiton { get; set; }
        public DbSet<PetRegistration> GetPetRegistration { get; set; }
        public DbSet<JobVacancy> GetVacancyRegistration { get; set; }
        public DbSet<Damakeba> Damakeba { get; set; }
    }
}
