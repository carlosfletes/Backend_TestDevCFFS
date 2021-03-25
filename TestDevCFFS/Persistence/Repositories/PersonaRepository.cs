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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persona>> GetList()
        {
            List < Persona > lista =  await _context.Tb_PersonasFisicas.Where(p => p.Activo.Equals(true)).ToListAsync();
            return lista;
        }

        public async Task<Persona> Get(int id)
        {
            Persona persona =  await _context.Tb_PersonasFisicas.Where(p => p.IdPersonaFisica.Equals(id) && p.Activo.Equals(true)).FirstOrDefaultAsync();
            return persona;
        }

        public async Task Delete(Persona persona)
        {
            persona.Activo = false;
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidaExistenciaRFC(string rfc)
        {
            return await _context.Tb_PersonasFisicas.AnyAsync(u => u.RFC == rfc);
        }
    }
}
