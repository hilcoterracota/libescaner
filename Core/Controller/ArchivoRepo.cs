using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libescaner.Core.Repository;
using libescaner.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core.Controller
{

    public class ArchivoRepo : IArchivo

    {
        private readonly LibEscanerDbContext context;
        public ArchivoRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<Archivo> Add(Archivo value)
        {
            await context.Archivo.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> Delete(Archivo value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Archivo> FindById(string value)
        {
            return await context.Archivo.Where(x => x.Id == value)
           .Include(i => i.ArchivoCategorias)
            .ThenInclude(i => i.Categoria)
           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Archivo>> GetAll()
        {
            return await context.Archivo
            .Include(i => i.ArchivoCategorias)
            .ThenInclude(i => i.Categoria)
            .ToListAsync();
        }

        public async Task<Archivo> Update(Archivo value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Archivo.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
    }
}