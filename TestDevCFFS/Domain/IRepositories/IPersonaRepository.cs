using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Domain.IRepositories
{
    public interface IPersonaRepository
    {

        Task Save(Persona persona);

        Task<List<Persona>> GetList();

        Task <Persona> Get(int id);

        Task Delete(Persona persona);

        Task<bool> ValidaExistenciaRFC(string rfc);
        
    }
}
