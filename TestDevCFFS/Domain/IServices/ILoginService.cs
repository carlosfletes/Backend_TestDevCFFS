using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidaUsuario(Usuario usuario);

    }
}
