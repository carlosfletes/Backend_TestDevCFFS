using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.IRepositories;
using TestDevAPI.Domain.IServices;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidaUsuario(Usuario usuario)
        {
           return await _loginRepository.ValidaUsuario(usuario);
        }


    }
}
