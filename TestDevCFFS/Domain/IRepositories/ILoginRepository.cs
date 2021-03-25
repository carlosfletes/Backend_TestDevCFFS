using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidaUsuario(Usuario usuario);
    }
}
