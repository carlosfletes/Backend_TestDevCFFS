using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.IRepositories;
using TestDevAPI.Domain.IServices;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task SaveUser(Usuario usuario)
        {
            await _usuarioRepository.SaveUser(usuario);
        }

        public async Task<bool> ValidaExistencia(Usuario usuario)
        {
            return await _usuarioRepository.ValidaExistencia(usuario);
        }

        public async Task<Usuario> ValidaPassword(int idUsuario, string newPassword)
        {
            return await _usuarioRepository.ValidaPassword(idUsuario, newPassword);
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            await _usuarioRepository.UpdatePassword(usuario);
        }
    }
}
