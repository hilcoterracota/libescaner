using System.Collections.Generic;
using System.Threading.Tasks;
using libescaner.Core;
using libescaner.Core.Repository;
using libescaner.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibEscaner.Core.Controller
{
    public class ClienteRepo : ICliente
    {
        private readonly LibEscanerDbContext context;

        public ClienteRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await context.Cliente
            .Include(x => x.Creditos)
                .ThenInclude(x => x.Acreditado)
                    .ThenInclude(x => x.Archivos)
                        .ThenInclude(x => x.TipoArchivo)
            .ToListAsync();
        }

        public async Task<Cliente> FindById(string value)
        {
            return await context.Cliente
            .Include(x => x.Creditos)
                .ThenInclude(x => x.Acreditado)
                    .ThenInclude(x => x.Archivos)
                        .ThenInclude(x => x.TipoArchivo)
            .FirstOrDefaultAsync(i => i.Id == value);
        }

        public async Task<Cliente> Add(Cliente value)
        {
            await context.Cliente.AddAsync(value);
            context.SaveChanges();
            return value;
        }
        
        public async Task<Cliente> Update(Cliente value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Cliente.FirstOrDefaultAsync(i => i.Id == value.Id);
        }

        public async Task<bool> Delete(Cliente value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }
    }
}