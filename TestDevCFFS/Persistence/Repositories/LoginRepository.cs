using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.IRepositories;
using TestDevAPI.Domain.Models;
using TestDevAPI.Persistence.Context;

namespace TestDevAPI.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidaUsuario(Usuario usuario)
        {
            return await _context.Tb_Usuarios.Where(u => u.NombreUsuario.Equals(usuario.NombreUsuario) && u.Password.Equals(usuario.Password)).FirstOrDefaultAsync();
        }
    }
}
