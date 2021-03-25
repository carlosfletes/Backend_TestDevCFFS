using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevAPI.Domain.IRepositories;
using TestDevAPI.Domain.IServices;
using TestDevAPI.Domain.Models;

namespace TestDevAPI.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task Save(Persona persona)
        {
            await _personaRepository.Save(persona);
        }

        public async Task<List<Persona>> GetList()
        {
           return await _personaRepository.GetList();
        }

        public async Task<Persona> Get(int id)
        {
            return await _personaRepository.Get(id);
        }

        public async Task Delete(Persona persona)
        {
             await _personaRepository.Delete(persona);
        }

        public async Task<bool> ValidaExistenciaRFC(string rfc)
        {
            return await _personaRepository.ValidaExistenciaRFC(rfc);
        }
    }
}
