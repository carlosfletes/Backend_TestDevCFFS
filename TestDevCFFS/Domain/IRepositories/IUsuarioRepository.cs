﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);

        Task<bool> ValidaExistencia(Usuario usuario);

        Task<Usuario> ValidaPassword(int idUsuario, string newPassword);

        Task UpdatePassword(Usuario usuario);
    }
}
