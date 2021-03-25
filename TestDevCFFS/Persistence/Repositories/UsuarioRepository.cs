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
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser (Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidaExistencia(Usuario usuario)
        {
            return await _context.Tb_Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario);
        }

        public async Task<Usuario> ValidaPassword(int idUsuario, string newPassword)
        {
            Usuario usuario = await _context.Tb_Usuarios.Where(u => u.Id == idUsuario && u.Password == newPassword).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }



    }
}
