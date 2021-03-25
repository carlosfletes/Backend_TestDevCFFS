using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Domain.IServices
{
    public interface IPersonaService
    {

        public Task Save(Persona persona);

        Task<List<Persona>> GetList();

        Task<Persona> Get(int id);

        Task Delete(Persona persona);

        Task<bool> ValidaExistenciaRFC(string rfc);
    }
}
