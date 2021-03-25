using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Persona> Tb_PersonasFisicas { get; set; }
        public DbSet<Usuario> Tb_Usuarios { get; set; }
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext>options) :base(options)
        {

        }

    }
}
